using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.ProstheticsCount
{
    [HarmonyPatch(typeof(ThoughtWorker_Precept_HasProsthetic_Count))]
    [HarmonyPatch(nameof(ThoughtWorker_Precept_HasProsthetic_Count.ProstheticsCount))]
    public static class Patch_ThoughtWorker_Precept_HasProsthetic_Count_ProstheticsCount
    {
        public static void Postfix(Pawn p, ref int __result)
        {
            __result = p.health.hediffSet.CountAddedAndImplantedParts();
        }
    }
}
