using HarmonyLib;
using RimWorld;
using Verse;

namespace IdeologyPatch.DarklightDefault
{
    [HarmonyPatch(typeof(Thing))]
    [HarmonyPatch(nameof(Thing.SetFactionDirect))]
    public static class Patch_Thing_SetFactionDirect
    {
        public static void Prefix(Thing __instance, Faction newFaction)
        {
            PatchUtility_Thing.SetDarklight(__instance, newFaction);
        }
    }

    [HarmonyPatch(typeof(Thing))]
    [HarmonyPatch(nameof(Thing.SetFaction))]
    public static class Patch_Thing_SetFaction
    {
        public static void Prefix(Thing __instance, Faction newFaction)
        {
            PatchUtility_Thing.SetDarklight(__instance, newFaction);
        }
    }

    public static class PatchUtility_Thing
    {
        public static void SetDarklight(Thing thing, Faction newFaction)
        {
            if (IdeologyPatchSettings.DarklightDefault)
            {
                CompGlower comp = thing.TryGetComp<CompGlower>();
                if (comp != null && comp.Props.darklightToggle)
                {
                    if (comp.parent.Faction == null && newFaction.IsPlayer && newFaction.ideos?.PrimaryIdeo?.HasPrecept(DefDatabase<PreceptDef>.GetNamed("Darklight_Preferred")) == true)
                    {
                        comp.GlowColor = new ColorInt(DarklightUtility.DefaultDarklight);
                    }
                }
            }
        }
    }
}
