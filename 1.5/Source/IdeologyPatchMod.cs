using HarmonyLib;
using RimWorld;
using System;
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
