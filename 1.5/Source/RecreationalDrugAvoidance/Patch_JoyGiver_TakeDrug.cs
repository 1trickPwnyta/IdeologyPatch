using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.ProstheticsCount
{
    [HarmonyPatch(typeof(JoyGiver_TakeDrug))]
    [HarmonyPatch(nameof(JoyGiver_TakeDrug.GetChance))]
    public static class Patch_JoyGiver_TakeDrug_GetChance
    {
        public static void Postfix(Pawn pawn, ref float __result)
        {
            if (IdeologyPatchSettings.RecreationalDrugAvoidance && pawn.IsTeetotaler())
            {
                __result = 0f;
            }
        }
    }
}
