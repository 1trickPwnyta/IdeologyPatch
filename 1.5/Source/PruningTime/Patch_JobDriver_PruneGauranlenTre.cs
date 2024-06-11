using HarmonyLib;
using RimWorld;

namespace IdeologyPatch.PruningTime
{
    [HarmonyPatch(typeof(JobDriver_PruneGauranlenTre))]
    [HarmonyPatch(nameof(JobDriver_PruneGauranlenTre.Notify_Starting))]
    public static class Patch_JobDriver_PruneGauranlenTre_Notify_Starting
    {
        public static void Postfix(ref int ___numPositions)
        {
            if (IdeologyPatchSettings.PruningTime)
            {
                ___numPositions = 1;
            }
        }
    }
}
