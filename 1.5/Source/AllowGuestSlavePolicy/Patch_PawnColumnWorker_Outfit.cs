using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

namespace IdeologyPatch.AllowGuestSlavePolicy
{
    [HarmonyPatch(typeof(PawnColumnWorker_Outfit))]
    [HarmonyPatch(nameof(PawnColumnWorker_Outfit.DoCell))]
    public static class Patch_PawnColumnWorker_Outfit
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool foundQuestLodger = false;
            bool finished = false;

            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Call && (MethodInfo)instruction.operand == typeof(QuestUtility).Method(nameof(QuestUtility.IsQuestLodger)))
                {
                    foundQuestLodger = true;
                }

                if (foundQuestLodger && !finished && instruction.opcode == OpCodes.Brfalse_S)
                {
                    yield return instruction;
                    yield return new CodeInstruction(OpCodes.Ldarg_2);
                    yield return new CodeInstruction(OpCodes.Call, typeof(PatchUtility_PawnColumnWorker_Outfit).Method(nameof(PatchUtility_PawnColumnWorker_Outfit.ShouldShowPolicyBecauseSlave)));
                    yield return new CodeInstruction(OpCodes.Brtrue_S, instruction.operand);
                    finished = true;
                    continue;
                }

                yield return instruction;
            }
        }
    }

    public static class PatchUtility_PawnColumnWorker_Outfit
    {
        public static bool ShouldShowPolicyBecauseSlave(Pawn pawn)
        {
            return IdeologyPatchSettings.AllowGuestSlavePolicy && pawn.IsSlaveOfColony;
        }
    }
}
