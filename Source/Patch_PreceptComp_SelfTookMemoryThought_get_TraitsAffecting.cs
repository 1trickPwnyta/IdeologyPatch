using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace IdeologyPatch
{
    [HarmonyPatch(typeof(PreceptComp_SelfTookMemoryThought))]
    [HarmonyPatch("get_TraitsAffecting")]
    public static class Patch_PreceptComp_SelfTookMemoryThought_get_TraitsAffecting
    {
        public static bool Prefix(PreceptComp_SelfTookMemoryThought __instance, ref IEnumerable<TraitRequirement> __result)
        {
            if (__instance.thought == null)
            {
                __result = new List<TraitRequirement>();
                Debug.Log("fixed it for realz???");
                return false;
            }
            return true;
        }
    }
}
