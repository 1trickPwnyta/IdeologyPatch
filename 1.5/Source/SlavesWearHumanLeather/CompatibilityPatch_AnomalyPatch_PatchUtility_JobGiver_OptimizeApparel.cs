using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace IdeologyPatch.SlavesWearHumanLeather
{
    // Patched manually in mod constructor
    public static class CompatibilityPatch_AnomalyPatch_PatchUtility_JobGiver_OptimizeApparel
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ldc_R4 && (float)instruction.operand == 0.5f)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_1);
                    yield return new CodeInstruction(OpCodes.Ldarg_2);
                    instruction.opcode = OpCodes.Call;
                    instruction.operand = typeof(PatchUtility_JobGiver_OptimizeApparel).Method(nameof(PatchUtility_JobGiver_OptimizeApparel.GetHumanLeatherApparelSadOffset));
                }

                yield return instruction;
            }
        }
    }
}
