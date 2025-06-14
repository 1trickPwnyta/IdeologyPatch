using HarmonyLib;
using RimWorld;

namespace IdeologyPatch.FactionRelationAdjustment
{
    [HarmonyPatch(typeof(FactionUtility))]
    [HarmonyPatch(nameof(FactionUtility.ResetAllFactionRelations))]
    public static class Patch_FactionUtility
    {
        public static void Postfix()
        {
            FactionRelationUtility.AdjustFactionRelations();
        }
    }
}
