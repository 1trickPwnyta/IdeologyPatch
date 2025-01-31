using HarmonyLib;
using IdeologyPatch.SlavesWearHumanLeather;
using UnityEngine;
using Verse;

namespace IdeologyPatch
{
    public class IdeologyPatchMod : Mod
    {
        public const string PACKAGE_ID = "ideologypatch.1trickPwnyta";
        public const string PACKAGE_NAME = "1trickPwnyta's Ideology Patch";

        public static IdeologyPatchSettings Settings;

        public IdeologyPatchMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();
            if (AccessTools.TypeByName("AnomalyPatch.AvoidDreadLeather.PatchUtility_JobGiver_OptimizeApparel") != null)
            {
                harmony.Patch(AccessTools.TypeByName("AnomalyPatch.AvoidDreadLeather.PatchUtility_JobGiver_OptimizeApparel").Method("ModifyApparelScore"), null, null, typeof(CompatibilityPatch_AnomalyPatch_PatchUtility_JobGiver_OptimizeApparel).Method(nameof(CompatibilityPatch_AnomalyPatch_PatchUtility_JobGiver_OptimizeApparel.Transpiler)));
            }

            Settings = GetSettings<IdeologyPatchSettings>();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }

        public override string SettingsCategory() => PACKAGE_NAME;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            IdeologyPatchSettings.DoSettingsWindowContents(inRect);
        }
    }
}
