using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch
{
    [HarmonyPatch(typeof(PreceptComp_SelfTookMemoryThought))]
    [HarmonyPatch(nameof(PreceptComp_SelfTookMemoryThought.Notify_MemberTookAction))]
    public static class Patch_PreceptComp_SelfTookMemoryThought_Notify_MemberTookAction
    {
        public static bool Prefix(PreceptComp_SelfTookMemoryThought __instance, HistoryEvent ev, Precept precept, bool canApplySelfTookThoughts)
        {
            if (__instance.thought == null)
            {
                return false;
            }
            return true;
        }
    }
}
