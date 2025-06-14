using HarmonyLib;
using Verse.AI;

namespace IdeologyPatch.DryadWanderRadius
{
    [HarmonyPatch(typeof(JobGiver_WanderNearConnectedTree))]
    [HarmonyPatch("TryGiveJob")]
    public static class Patch_JobGiver_WanderNearConnectedTree_TryGiveJob
    {
        public static void Postfix(ref float ___wanderRadius)
        {
            if (IdeologyPatchSettings.DryadWanderRadius)
            {
                ___wanderRadius = 7.9f;
            }
            else
            {
                ___wanderRadius = 12f;
            }
        }
    }
}
