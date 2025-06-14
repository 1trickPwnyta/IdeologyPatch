using HarmonyLib;
using Verse;

namespace IdeologyPatch.FactionRelationAdjustment
{
    [HarmonyPatch(typeof(Game))]
    [HarmonyPatch(nameof(Game.FinalizeInit))]
    public static class Patch_Game
    {
        public static void Postfix()
        {
            FactionRelationUtility.AdjustFactionRelations();
        }
    }
}
