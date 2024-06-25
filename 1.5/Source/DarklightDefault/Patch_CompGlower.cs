using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.DarklightDefault
{
    [HarmonyPatch(typeof(CompGlower))]
    [HarmonyPatch(nameof(CompGlower.PostSpawnSetup))]
    public static class Patch_CompGlower_PostSpawnSetup
    {
        public static void Postfix(CompGlower __instance, bool respawningAfterLoad)
        {
            if (IdeologyPatchSettings.DarklightDefault && __instance.Props.darklightToggle && !respawningAfterLoad)
            {
                if (__instance.parent.Faction == Faction.OfPlayer && Faction.OfPlayer.ideos != null && Faction.OfPlayer.ideos.PrimaryIdeo != null && Faction.OfPlayer.ideos.PrimaryIdeo.HasPrecept(DefDatabase<PreceptDef>.GetNamed("Darklight_Preferred")))
                {
                    __instance.GlowColor = new ColorInt(DarklightUtility.DefaultDarklight);
                }
            }
        }
    }
}
