using LudeonTK;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace IdeologyPatch.LookChangeDesiredFix
{
    public static class LookChangeDesiredUtility
    {
        private static List<StyleItemDef> allowedHairs;
        private static List<StyleItemDef> allowedBeards;
        private static List<StyleItemDef> allowedFaceTattoos;
        private static List<StyleItemDef> allowedBodyTattoos;

        public static bool CanUseStyle(Pawn pawn, StyleItemDef style, TattooType? tattooType, bool allowCache = false)
        {
            List<StyleItemDef> allowedItems = null;
            if (style is HairDef)
            {
                if (!allowCache || allowedHairs == null)
                {
                    List<StyleItemDef> geneAllowedItems = DefDatabase<HairDef>.AllDefsListForReading.Where(h => pawn.genes.StyleItemAllowed(h)).Cast<StyleItemDef>().ToList();
                    List<StyleItemDef> ideoAllowedItems = DefDatabase<HairDef>.AllDefsListForReading.Where(h => pawn.Ideo.style.GetFrequency(h) > StyleItemFrequency.Never).Cast<StyleItemDef>().ToList();
                    allowedHairs = geneAllowedItems.Intersect(ideoAllowedItems).ToList();
                }
                allowedItems = allowedHairs;
            }
            else if (style is BeardDef)
            {
                if (!allowCache || allowedBeards == null)
                {
                    List<StyleItemDef> geneAllowedItems = DefDatabase<BeardDef>.AllDefsListForReading.Where(b => pawn.genes.StyleItemAllowed(b)).Cast<StyleItemDef>().ToList();
                    List<StyleItemDef> ideoAllowedItems = DefDatabase<BeardDef>.AllDefsListForReading.Where(b => pawn.Ideo.style.GetFrequency(b) > StyleItemFrequency.Never).Cast<StyleItemDef>().ToList();
                    allowedBeards = geneAllowedItems.Intersect(ideoAllowedItems).ToList();
                }
                allowedItems = allowedBeards;
            }
            else if (style is TattooDef && tattooType.HasValue)
            {
                if (!allowCache || (tattooType == TattooType.Face && allowedFaceTattoos == null) || (tattooType == TattooType.Body && allowedBodyTattoos == null))
                {
                    List<StyleItemDef> geneAllowedItems = DefDatabase<TattooDef>.AllDefsListForReading.Where(t => t.tattooType == tattooType.Value && pawn.genes.StyleItemAllowed(t)).Cast<StyleItemDef>().ToList();
                    List<StyleItemDef> ideoAllowedItems = DefDatabase<TattooDef>.AllDefsListForReading.Where(t => t.tattooType == tattooType.Value && pawn.Ideo.style.GetFrequency(t) > StyleItemFrequency.Never).Cast<StyleItemDef>().ToList();
                    if (tattooType == TattooType.Face)
                    {
                        allowedFaceTattoos = geneAllowedItems.Intersect(ideoAllowedItems).ToList();
                    }
                    else if (tattooType == TattooType.Body)
                    {
                        allowedBodyTattoos = geneAllowedItems.Intersect(ideoAllowedItems).ToList();
                    }
                }
                if (tattooType == TattooType.Face)
                {
                    allowedItems = allowedFaceTattoos;
                }
                else if (tattooType == TattooType.Body)
                {
                    allowedItems = allowedBodyTattoos;
                }
            }
            else
            {
                return true;
            }

            if (allowedItems.Any())
            {
                if (!allowedItems.Contains(style))
                {
                    return false;
                }
            }

            return true;
        }

        public static void ClearCache()
        {
            allowedHairs = null;
            allowedBeards = null;
            allowedFaceTattoos = null;
            allowedBodyTattoos = null;
        }

#if DEBUG
        [DebugAction("Pawns", "Force look change desire", actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void ForceLookChangeDesire(Pawn p)
        {
            if (p.style.CanDesireLookChange && p.style.HasAnyUnwantedStyleItem)
            {
                p.style.RequestLookChange();
                p.style.nextStyleChangeAttemptTick = GenTicks.TicksGame;
            }
            else
            {
                Messages.Message(p.LabelShortCap + " is already happy with their look.", MessageTypeDefOf.RejectInput, false);
            }
        }
#endif
    }
}
