using HarmonyLib;
using Verse;

namespace IdeologyPatch.FactionRelationAdjustment
{
    [HarmonyPatch(typeof(Game))]
    [HarmonyPatch(nameof(Game.InitNewGame))]
    public static class Patch_Game
    {
        public static void Postfix()
        {
            FactionRelationUtility.AdjustFactionRelations();
        }
    }
}
