using HarmonyLib;
using RimWorld;

namespace IdeologyPatch.LookChangeDesiredFix
{
    [HarmonyPatch(typeof(Dialog_StylingStation))]
    [HarmonyPatch(nameof(Dialog_StylingStation.PostOpen))]
    public static class Patch_Dialog_StylingStation
    {
        public static void Postfix()
        {
            LookChangeDesiredUtility.ClearCache();
        }
    }
}
