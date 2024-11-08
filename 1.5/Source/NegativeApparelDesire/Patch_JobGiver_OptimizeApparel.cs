using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using Verse;

namespace IdeologyPatch.NegativeApparelDesire
{
    [HarmonyPatch(typeof(JobGiver_OptimizeApparel))]
    [HarmonyPatch(nameof(JobGiver_OptimizeApparel.ApparelScoreRaw))]
    public static class Patch_JobGiver_OptimizeApparel
    {
        // Prevents vanilla bug in dev mode that throws errors when apparel logging options are on
        public static bool Prefix(Pawn pawn, ref float __result)
        {
            if (pawn == null)
            {
                __result = 0f;
                return false;
            }
            return true;
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
        {
            bool foundMechanitor = false;
            bool foundBrtrue = false;
            bool foundRet = false;
            Label postNegativeApparelLabel = default;
            Label desireCheckLabel = il.DefineLabel();

            foreach (CodeInstruction instruction in instructions)
            {
                if (!foundMechanitor && instruction.opcode == OpCodes.Ldfld && (FieldInfo)instruction.operand == typeof(ApparelProperties).Field(nameof(ApparelProperties.mechanitorApparel)))
                {
                    foundMechanitor = true;
                }
                if (foundMechanitor && instruction.opcode == OpCodes.Brfalse_S)
                {
                    postNegativeApparelLabel = (Label)instruction.operand;
                    break;
                }
            }

            if (postNegativeApparelLabel == default)
            {
                throw new System.Exception("Failed to patch JobGiver_OptimizeApparel. Post negative apparel label not found.");
            }

            foreach (CodeInstruction instruction in instructions)
            {
                if (!foundBrtrue && instruction.opcode == OpCodes.Brtrue_S)
                {
                    instruction.operand = desireCheckLabel;
                    foundBrtrue = true;
                }
                if (!foundRet && instruction.opcode == OpCodes.Ret)
                {
                    yield return instruction;
                    CodeInstruction desireCheckInstruction = new CodeInstruction(OpCodes.Ldarg_0);
                    desireCheckInstruction.labels.Add(desireCheckLabel);
                    yield return desireCheckInstruction;
                    yield return new CodeInstruction(OpCodes.Ldarg_1);
                    yield return new CodeInstruction(OpCodes.Call, typeof(PatchUtility_JobGiver_OptimizeApparel).Method(nameof(PatchUtility_JobGiver_OptimizeApparel.Desires)));
                    yield return new CodeInstruction(OpCodes.Brtrue, postNegativeApparelLabel);
                    foundRet = true;
                    continue;
                }
                if (instruction.opcode == OpCodes.Ldfld && (FieldInfo)instruction.operand == typeof(ApparelProperties).Field(nameof(ApparelProperties.scoreOffset)))
                {
                    yield return new CodeInstruction(OpCodes.Pop);
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldarg_1);
                    yield return new CodeInstruction(OpCodes.Call, typeof(PatchUtility_JobGiver_OptimizeApparel).Method(nameof(PatchUtility_JobGiver_OptimizeApparel.AdjustedScoreOffset)));
                    continue;
                }

                yield return instruction;
            }
        }
    }

    public static class PatchUtility_JobGiver_OptimizeApparel
    {
        public static bool Desires(this Pawn pawn, Apparel apparel)
        {
            return IdeologyPatchSettings.NegativeApparelDesire && pawn.Ideo != null && pawn.Ideo.PreceptsListForReading.Where(p => p is Precept_Apparel).Select(p => (Precept_Apparel)p).Any(p => (p.TargetGender == Gender.None || p.TargetGender == pawn.gender) && p.apparelDef == apparel.def);
        }

        public static float AdjustedScoreOffset(Pawn pawn, Apparel apparel)
        {
            return pawn.Desires(apparel) ? Mathf.Max(apparel.def.apparel.scoreOffset, 0f) : apparel.def.apparel.scoreOffset;
        }
    }
}
