using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.LookChangeDesiredFix
{
    [HarmonyPatch(typeof(PawnStyleItemChooser))]
    [HarmonyPatch(nameof(PawnStyleItemChooser.WantsToUseStyle))]
    public static class Patch_PawnStyleItemChooser
    {
        public static void Postfix(Pawn pawn, StyleItemDef styleItemDef, TattooType? tattooType, ref bool __result)
        {
            // Compatibility patch for HAR
            if (pawn.def.GetType().Name == "ThingDef_AlienRace")
            {
                return;
            }

            if (IdeologyPatchSettings.LookChangeDesiredFix && pawn.genes != null && pawn.Ideo != null && !Find.IdeoManager.classicMode)
            {
                if (!LookChangeDesiredUtility.CanUseStyle(pawn, styleItemDef, tattooType, Find.WindowStack.TryGetWindow<Dialog_StylingStation>(out _)))
                {
                    __result = false;
                }
            }
        }
    }
}
