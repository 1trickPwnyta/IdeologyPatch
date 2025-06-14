using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.FungusPreferredDisablesDarkThought
{
    [HarmonyPatch(typeof(ThoughtWorker_Dark))]
    [HarmonyPatch("CurrentStateInternal")]
    public static class Patch_ThoughtWorker_Dark
    {
        public static void Postfix(Pawn p, ref ThoughtState __result)
        {
            if (IdeologyPatchSettings.FungusPreferredDisablesDarkThought && __result.Active && p.Ideo != null && p.Ideo.PreceptsListForReading.Any(precept => precept.def == DefDatabase<PreceptDef>.GetNamed("FungusEating_Preferred")))
            {
                __result = false;
            }
        }
    }
}
