using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace IdeologyPatch
{
    public class IdeologyPatchMod : Mod
    {
        public const string PACKAGE_ID = "ideologypatch.1trickPwnyta";
        public const string PACKAGE_NAME = "1trickPwnyta's Ideology Patch";

        public IdeologyPatchMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();
            harmony.Patch(typeof(CompTreeConnection).GetConstructor(new Type[] { }), null, typeof(PruningTime.Patch_CompTreeConnection_ctor).GetMethod("Postfix"));

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
