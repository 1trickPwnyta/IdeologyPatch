using HarmonyLib;
using RimWorld;
using RimWorld.BaseGen;
using System.Collections.Generic;
using System.Reflection.Emit;
using Verse;

namespace IdeologyPatch.ForbidArchonexusCorpses
{
    [HarmonyPatch(typeof(SymbolResolver_DesiccatedCorpses))]
    [HarmonyPatch("SpawnCorpse")]
    public static class Patch_SymbolResolver_DesiccatedCorpses
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (CodeInstruction instruction in instructions)
            {
                if (instruction.opcode == OpCodes.Ret)
                {
                    yield return new CodeInstruction(OpCodes.Ldloc_0);
                    yield return new CodeInstruction(OpCodes.Ldarg_S, 4);
                    yield return new CodeInstruction(OpCodes.Call, typeof(PatchUtility_SymbolResolver_DesiccatedCorpses).Method(nameof(PatchUtility_SymbolResolver_DesiccatedCorpses.ForbidPawnCorpse)));
                }

                yield return instruction;
            }
        }
    }

    public static class PatchUtility_SymbolResolver_DesiccatedCorpses
    {
        public static void ForbidPawnCorpse(Pawn p, Map m)
        {
            if (IdeologyPatchSettings.ForbidArchonexusCorpses && m.IsPlayerHome)
            {
                p.Corpse.SetForbidden(true);
            }
        }
    }
}
