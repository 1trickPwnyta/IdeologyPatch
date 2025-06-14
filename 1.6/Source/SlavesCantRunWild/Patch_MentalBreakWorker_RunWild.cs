using HarmonyLib;
using Verse;
using Verse.AI;

namespace IdeologyPatch.SlavesCantRunWild
{
    [HarmonyPatch(typeof(MentalBreakWorker_RunWild))]
    [HarmonyPatch(nameof(MentalBreakWorker_RunWild.BreakCanOccur))]
    public static class Patch_MentalBreakWorker_RunWild
    {
        public static void Postfix(Pawn pawn, ref bool __result)
        {
            if (IdeologyPatchSettings.SlavesCantRunWild && pawn.IsSlave)
            {
                __result = false;
            }
        }
    }
}
