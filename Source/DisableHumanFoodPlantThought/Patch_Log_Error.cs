using HarmonyLib;
using Verse;

namespace IdeologyPatch.DisableHumanFoodPlantThought
{
    [HarmonyPatch(typeof(Log))]
    [HarmonyPatch(nameof(Log.Error))]
    [HarmonyPatch(new[] { typeof(string) })]
    public static class Patch_Log_Error
    {
        public static bool Prefix(string text)
        {
            return !text.Contains("Ranching_SowedPlant");
        }
    }
}
