using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace IdeologyPatch.LookChangeDesiredFix
{
    //[HarmonyPatch(typeof(JobGiver_UseStylingStationAutomatic))]
    //[HarmonyPatch("TryGiveJob")]
    public static class Patch_JobGiver_UseStylingStationAutomatic
    {
        public static void Postfix(Pawn pawn, ref Job __result)
        {
            if (IdeologyPatchSettings.LookChangeDesiredFix)
            {
                bool giveJob = false;

                if (!PawnStyleItemChooser.WantsToUseStyle(pawn, pawn.story.hairDef) && DefDatabase<HairDef>.AllDefsListForReading.Any(d => PawnStyleItemChooser.WantsToUseStyle(pawn, d)))
                {
                    giveJob = true;
                }
                if (!PawnStyleItemChooser.WantsToUseStyle(pawn, pawn.style.beardDef) && DefDatabase<BeardDef>.AllDefsListForReading.Any(d => PawnStyleItemChooser.WantsToUseStyle(pawn, d)))
                {
                    giveJob = true;
                }
                if (!PawnStyleItemChooser.WantsToUseStyle(pawn, pawn.style.FaceTattoo, TattooType.Face) && DefDatabase<TattooDef>.AllDefsListForReading.Any(d => PawnStyleItemChooser.WantsToUseStyle(pawn, d, TattooType.Face)))
                {
                    giveJob = true;
                }
                if (!PawnStyleItemChooser.WantsToUseStyle(pawn, pawn.style.BodyTattoo, TattooType.Body) && DefDatabase<TattooDef>.AllDefsListForReading.Any(d => PawnStyleItemChooser.WantsToUseStyle(pawn, d, TattooType.Body)))
                {
                    giveJob = true;
                }

                if (!giveJob)
                {
                    __result = null;
                }
            }
        }
    }
}
