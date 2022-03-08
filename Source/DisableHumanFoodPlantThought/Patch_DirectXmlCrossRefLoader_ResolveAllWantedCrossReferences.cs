using HarmonyLib;
using System;
using System.Reflection;
using Verse;

namespace IdeologyPatch.DisableHumanFoodPlantThought
{
    [HarmonyPatch(typeof(DirectXmlCrossRefLoader))]
    [HarmonyPatch(nameof(DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef))]
    [HarmonyPatch(new[] { typeof(object), typeof(FieldInfo), typeof(string), typeof(string), typeof(Type) })]
    public static class Patch_DirectXmlCrossRefLoader_ResolveAllWantedCrossReferences
    {
        public static bool Prefix(string targetDefName)
        {
            return targetDefName != "Ranching_SowedPlant";
        }
    }
}
