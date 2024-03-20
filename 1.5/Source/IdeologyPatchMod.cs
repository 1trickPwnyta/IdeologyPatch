using HarmonyLib;
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

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
