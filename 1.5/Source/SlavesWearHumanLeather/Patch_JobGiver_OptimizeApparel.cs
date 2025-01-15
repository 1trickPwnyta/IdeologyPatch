using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace IdeologyPatch.SlavesWearHumanLeather
{
    [HarmonyPatch(typeof(JobGiver_OptimizeApparel))]
    [HarmonyPatch(nameof(JobGiver_OptimizeApparel.ApparelScoreRaw))]
    public static class Patch_JobGiver_OptimizeApparel
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool foundSad = false;
            bool finished = false;

            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldsfld && (FieldInfo)instruction.operand == typeof(ThoughtDefOf).Field(nameof(ThoughtDefOf.HumanLeatherApparelSad)))
                {
                    foundSad = true;
                }
                if (foundSad && !finished && instruction.opcode == OpCodes.Ldc_R4)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldarg_1);
                    yield return new CodeInstruction(OpCodes.Call, typeof(PatchUtility_JobGiver_OptimizeApparel).Method(nameof(PatchUtility_JobGiver_OptimizeApparel.GetHumanLeatherApparelSadOffset)));
                    finished = true;
                    continue;
                }

                yield return instruction;
            }
        }
    }

    public static class PatchUtility_JobGiver_OptimizeApparel
    {
        public static float GetHumanLeatherApparelSadOffset(Pawn pawn, Apparel ap)
        {
            if (IdeologyPatchSettings.SlavesWearHumanLeather && pawn.IsSlave && ap.def.apparel.slaveApparel)
            {
                return 0f;
            }
            else
            {
                return 0.5f;
            }
        }
    }
}
