using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace IdeologyPatch.ResearchMissingMemes
{
    [HarmonyPatch(typeof(MainTabWindow_Research))]
    [HarmonyPatch("ComputeUnlockedDefsThatHaveMissingMemes")]
    public static class Patch_MainTabWindow_Research_ComputeUnlockedDefsThatHaveMissingMemes
    {
        public static void Postfix(ref List<ValueTuple<BuildableDef, List<string>>> __result, ResearchProjectDef project)
        {
            if (__result.Count < project.UnlockedDefs.Count)
            {
                __result = new List<ValueTuple<BuildableDef, List<string>>>();
            }
        }
    }
}
