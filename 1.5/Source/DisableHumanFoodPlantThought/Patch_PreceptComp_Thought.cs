using HarmonyLib;
using RimWorld;
using System.Collections.Generic;

namespace IdeologyPatch
{
    [HarmonyPatch(typeof(PreceptComp_Thought))]
    [HarmonyPatch(nameof(PreceptComp_Thought.GetDescriptions))]
    public static class Patch_PreceptComp_Thought_GetDescriptions
    {
        public static bool Prefix(PreceptComp_Thought __instance, ref IEnumerable<string> __result)
        {
            if (IdeologyPatchSettings.DisableHumanFoodPlantThought && __instance.thought == ThoughtDef.Named("Ranching_SowedPlant"))
            {
                __result = new List<string>();
                return false;
            }
            return true;
        }
    }
}
