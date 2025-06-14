using HarmonyLib;
using RimWorld;

namespace IdeologyPatch
{
    [HarmonyPatch(typeof(PreceptComp_SelfTookMemoryThought))]
    [HarmonyPatch(nameof(PreceptComp_SelfTookMemoryThought.Notify_MemberTookAction))]
    public static class Patch_PreceptComp_SelfTookMemoryThought_Notify_MemberTookAction
    {
        public static bool Prefix(PreceptComp_SelfTookMemoryThought __instance)
        {
            if (IdeologyPatchSettings.DisableHumanFoodPlantThought && __instance.thought == ThoughtDef.Named("Ranching_SowedPlant"))
            {
                return false;
            }
            return true;
        }
    }
}
