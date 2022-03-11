using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Linq;
using Verse;

namespace IdeologyPatch.PrisonerConversionLetterJumpToPrisoner
{
    public static class Patch_InteractionWorker_ConvertIdeoAttempt_Interacted
    {
        [HarmonyPatch(typeof(InteractionWorker_ConvertIdeoAttempt))]
        [HarmonyPatch(nameof(InteractionWorker_ConvertIdeoAttempt.Interacted))]
        public static class Patch_PreceptComp_SelfTookMemoryThought_get_TraitsAffecting
        {
            public static void Postfix(Pawn initiator, Pawn recipient, LookTargets lookTargets)
            {
                if (lookTargets != null)
                {
                    lookTargets.targets = (new GlobalTargetInfo[] { recipient, initiator }).ToList();
                }
            }
        }
    }
}
