using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.SlavesArentQuestLodgers
{
    [HarmonyPatch(typeof(QuestUtility))]
    [HarmonyPatch(nameof(QuestUtility.IsQuestLodger))]
    public static class Patch_QuestUtility
    {
        public static void Postfix(Pawn p, ref bool __result)
        {
            if (IdeologyPatchSettings.SlavesArentQuestLodgers && p.IsSlaveOfColony)
            {
                __result = false;
            }
        }
    }
}
