using HarmonyLib;
using System;
using Verse.AI;

namespace IdeologyPatch.DryadWanderRadius
{
    [HarmonyPatch(typeof(JobGiver_WanderNearConnectedTree))]
    [HarmonyPatch("TryGiveJob")]
    public static class Patch_JobGiver_WanderNearConnectedTree_ctor
    {
        public static bool Prefix(ref float ___wanderRadius)
        {
            ___wanderRadius = 7f;
            return true;
        }
    }
}
