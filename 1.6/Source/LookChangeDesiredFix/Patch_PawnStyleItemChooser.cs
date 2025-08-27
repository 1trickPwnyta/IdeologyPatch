using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace IdeologyPatch.LookChangeDesiredFix
{
    [HarmonyPatch(typeof(PawnStyleItemChooser))]
    [HarmonyPatch(nameof(PawnStyleItemChooser.WantsToUseStyle))]
    public static class Patch_PawnStyleItemChooser
    {
        public static void Postfix(Pawn pawn, StyleItemDef styleItemDef, TattooType? tattooType, ref bool __result)
        {
            if (IdeologyPatchSettings.LookChangeDesiredFix && pawn.genes != null && pawn.Ideo != null && !Find.IdeoManager.classicMode)
            {
                List<StyleItemDef> geneAllowedItems, ideoAllowedItems;
                if (styleItemDef is HairDef)
                {
                    geneAllowedItems = DefDatabase<HairDef>.AllDefsListForReading.Where(h => pawn.genes.StyleItemAllowed(h)).Cast<StyleItemDef>().ToList();
                    ideoAllowedItems = DefDatabase<HairDef>.AllDefsListForReading.Where(h => pawn.Ideo.style.GetFrequency(h) > StyleItemFrequency.Never).Cast<StyleItemDef>().ToList();
                }
                else if (styleItemDef is BeardDef)
                {
                    geneAllowedItems = DefDatabase<BeardDef>.AllDefsListForReading.Where(b => pawn.genes.StyleItemAllowed(b)).Cast<StyleItemDef>().ToList();
                    ideoAllowedItems = DefDatabase<BeardDef>.AllDefsListForReading.Where(b => pawn.Ideo.style.GetFrequency(b) > StyleItemFrequency.Never).Cast<StyleItemDef>().ToList();
                }
                else if (styleItemDef is TattooDef && tattooType.HasValue)
                {
                    geneAllowedItems = DefDatabase<TattooDef>.AllDefsListForReading.Where(t => t.tattooType == tattooType.Value && pawn.genes.StyleItemAllowed(t)).Cast<StyleItemDef>().ToList();
                    ideoAllowedItems = DefDatabase<TattooDef>.AllDefsListForReading.Where(t => t.tattooType == tattooType.Value && pawn.Ideo.style.GetFrequency(t) > StyleItemFrequency.Never).Cast<StyleItemDef>().ToList();
                }
                else
                {
                    return;
                }

                List<StyleItemDef> overlapAllowedItems = geneAllowedItems.Intersect(ideoAllowedItems).ToList();
                if (overlapAllowedItems.Any())
                {
                    if (!overlapAllowedItems.Contains(styleItemDef))
                    {
                        __result = false;
                    }
                }
            }
        }
    }
}
