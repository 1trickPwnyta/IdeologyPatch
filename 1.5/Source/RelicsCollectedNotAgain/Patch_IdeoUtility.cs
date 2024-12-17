using HarmonyLib;
using RimWorld;

namespace IdeologyPatch.RelicsCollectedNotAgain
{
    [HarmonyPatch(typeof(IdeoUtility))]
    [HarmonyPatch(nameof(IdeoUtility.Notify_NewColonyStarted))]
    public static class Patch_IdeoUtility
    {
        public static void Postfix()
        {
            if (IdeologyPatchSettings.RelicsCollectedNotAgain)
            {
                foreach (Ideo ideo in Faction.OfPlayer.ideos.AllIdeos)
                {
                    if ((bool)typeof(Ideo).Method("AllRelicsNewlyCollected").Invoke(ideo, new object[] { }))
                    {
                        ideo.relicsCollected = true;
                    }
                }
            }
        }
    }
}
