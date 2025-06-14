using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.LookChangeDesiredFix
{
    [HarmonyPatch(typeof(PawnStyleItemChooser))]
    [HarmonyPatch(nameof(PawnStyleItemChooser.WantsToUseStyle))]
    public static class Patch_PawnStyleItemChooser
    {
        public static void Postfix(Pawn pawn, StyleItemDef styleItemDef, ref bool __result)
        {
            if (IdeologyPatchSettings.LookChangeDesiredFix && pawn.Ideo != null && !Find.IdeoManager.classicMode && pawn.Ideo.style.GetFrequency(styleItemDef) == StyleItemFrequency.Never)
            {
                __result = false;
            }
        }
    }
}
