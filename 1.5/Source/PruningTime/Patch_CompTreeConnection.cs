using HarmonyLib;
using RimWorld;

namespace IdeologyPatch.PruningTime
{
    [HarmonyPatch(typeof(CompTreeConnection))]
    [HarmonyPatch(nameof(CompTreeConnection.ShouldBePrunedNow))]
    public static class Patch_CompTreeConnection_ShouldBePrunedNow
    {
        public static void Prefix(ref float ___TimeBetweenAutoPruning)
        {
            if (IdeologyPatchSettings.PruningTime)
            {
                ___TimeBetweenAutoPruning = 0f;
            }
            else
            {
                ___TimeBetweenAutoPruning = 10000f;
            }
        }
    }
}
