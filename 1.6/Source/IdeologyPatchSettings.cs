using UnityEngine;
using Verse;

namespace IdeologyPatch
{
    public class IdeologyPatchSettings : ModSettings
    {
        public static bool DisableHumanFoodPlantThought = true;
        public static bool DryadWanderRadius = true;
        public static bool PrisonerConversionLetterJumpToPrisoner = true;
        public static bool PruningTime = true;
        public static bool ResearchMissingMemes = true;
        public static bool RoleChangeUseUntaken = true;
        public static bool BloodfeedingCorpsesDontCare = true;
        public static bool PremaritalSex = true;
        public static bool FemaleNudity = true;
        public static bool PantsOnly = true;
        public static bool FungusPreferredDisablesDarkThought = true;
        public static bool DarklightDefault = true;
        public static bool RitualCooldownMessage = true;
        public static bool LookChangeDesiredFix = true;
        public static bool NegativeApparelDesire = true;
        public static bool RelicsCollectedNotAgain = true;
        public static bool ForbidArchonexusCorpses = true;
        public static bool FactionRelationAdjustment = true;
        public static bool SlavesArentQuestLodgers = true;
        public static bool PaintableIdeoFloors = true;
        public static bool SlavesWearHumanLeather = true;
        public static bool SlavesCantRunWild = true;

        private static Vector2 scrollPosition;
        private static float y;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Rect viewRect = new Rect(0f, 0f, inRect.width - 20f, y);
            Widgets.BeginScrollView(inRect, ref scrollPosition, viewRect);

            Listing_Standard listing = new Listing_Standard() { maxOneColumn = true };
            listing.Begin(viewRect);

            DoHeader(listing, "IdeologyPatch_MemesPrecepts");
            listing.CheckboxLabeled("IdeologyPatch_PremaritalSex".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref PremaritalSex);
            listing.CheckboxLabeled("IdeologyPatch_FemaleNudity".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref FemaleNudity);
            listing.CheckboxLabeled("IdeologyPatch_PantsOnly".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref PantsOnly);
            listing.CheckboxLabeled("IdeologyPatch_DisableHumanFoodPlantThought".Translate(), ref DisableHumanFoodPlantThought);
            if (ModsConfig.BiotechActive)
            {
                listing.CheckboxLabeled("IdeologyPatch_BloodfeedingCorpsesDontCare".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref BloodfeedingCorpsesDontCare);
            }
            listing.CheckboxLabeled("IdeologyPatch_FungusPreferredDisablesDarkThought".Translate(), ref FungusPreferredDisablesDarkThought);
            listing.CheckboxLabeled("IdeologyPatch_DarklightDefault".Translate(), ref DarklightDefault);
            listing.CheckboxLabeled("IdeologyPatch_ResearchMissingMemes".Translate(), ref ResearchMissingMemes);

            listing.Gap();

            DoHeader(listing, "IdeologyPatch_Slaves");
            listing.CheckboxLabeled("IdeologyPatch_SlavesArentQuestLodgers".Translate(), ref SlavesArentQuestLodgers);
            listing.CheckboxLabeled("IdeologyPatch_SlavesWearHumanLeather".Translate(), ref SlavesWearHumanLeather);
            listing.CheckboxLabeled("IdeologyPatch_SlavesCantRunWild".Translate(), ref SlavesCantRunWild);

            listing.Gap();

            DoHeader(listing, "IdeologyPatch_Practices");
            listing.CheckboxLabeled("IdeologyPatch_PrisonerConversionLetterJumpToPrisoner".Translate(), ref PrisonerConversionLetterJumpToPrisoner);
            listing.CheckboxLabeled("IdeologyPatch_RoleChangeUseUntaken".Translate(), ref RoleChangeUseUntaken);
            listing.CheckboxLabeled("IdeologyPatch_RitualCooldownMessage".Translate(), ref RitualCooldownMessage);
            listing.CheckboxLabeled("IdeologyPatch_LookChangeDesiredFix".Translate(), ref LookChangeDesiredFix);
            listing.CheckboxLabeled("IdeologyPatch_NegativeApparelDesire".Translate(), ref NegativeApparelDesire);

            listing.Gap();

            DoHeader(listing, "IdeologyPatch_Misc");
            listing.CheckboxLabeled("IdeologyPatch_PruningTime".Translate(), ref PruningTime);
            listing.CheckboxLabeled("IdeologyPatch_DryadWanderRadius".Translate(), ref DryadWanderRadius);
            listing.CheckboxLabeled("IdeologyPatch_RelicsCollectedNotAgain".Translate(), ref RelicsCollectedNotAgain);
            listing.CheckboxLabeled("IdeologyPatch_ForbidArchonexusCorpses".Translate(), ref ForbidArchonexusCorpses);
            listing.CheckboxLabeled("IdeologyPatch_FactionRelationAdjustment".Translate(), ref FactionRelationAdjustment);
            listing.CheckboxLabeled("IdeologyPatch_PaintableIdeoFloors".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref PaintableIdeoFloors);

            y = listing.CurHeight;
            listing.End();

            Widgets.EndScrollView();
        }

        private static void DoHeader(Listing_Standard listing, string key)
        {
            using (new TextBlock(GameFont.Medium))
            {
                listing.Label(key.Translate());
            }
            listing.GapLine();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref DisableHumanFoodPlantThought, "DisableHumanFoodPlantThought", true);
            Scribe_Values.Look(ref DryadWanderRadius, "DryadWanderRadius", true);
            Scribe_Values.Look(ref PrisonerConversionLetterJumpToPrisoner, "PrisonerConversionLetterJumpToPrisoner", true);
            Scribe_Values.Look(ref PruningTime, "PruningTime", true);
            Scribe_Values.Look(ref ResearchMissingMemes, "ResearchMissingMemes", true);
            Scribe_Values.Look(ref RoleChangeUseUntaken, "RoleChangeUseUntaken", true);
            Scribe_Values.Look(ref BloodfeedingCorpsesDontCare, "BloodfeedingCorpsesDontCare", true);
            Scribe_Values.Look(ref PremaritalSex, "PremaritalSex", true);
            Scribe_Values.Look(ref FemaleNudity, "FemaleNudity", true);
            Scribe_Values.Look(ref PantsOnly, "PantsOnly", true);
            Scribe_Values.Look(ref FungusPreferredDisablesDarkThought, "FungusPreferredDisablesDarkThought", true);
            Scribe_Values.Look(ref DarklightDefault, "DarklightDefault", true);
            Scribe_Values.Look(ref RitualCooldownMessage, "RitualCooldownMessage", true);
            Scribe_Values.Look(ref LookChangeDesiredFix, "LookChangeDesiredFix", true);
            Scribe_Values.Look(ref NegativeApparelDesire, "NegativeApparelDesire", true);
            Scribe_Values.Look(ref RelicsCollectedNotAgain, "RelicsCollectedNotAgain", true);
            Scribe_Values.Look(ref ForbidArchonexusCorpses, "ForbidArchonexusCorpses", true);
            Scribe_Values.Look(ref FactionRelationAdjustment, "FactionRelationAdjustment", true);
            Scribe_Values.Look(ref SlavesArentQuestLodgers, "SlavesArentQuestLodgers", true);
            Scribe_Values.Look(ref PaintableIdeoFloors, "PaintableIdeoFloors", true);
            Scribe_Values.Look(ref SlavesWearHumanLeather, "SlavesWearHumanLeather", true);
            Scribe_Values.Look(ref SlavesCantRunWild, "SlavesCantRunWild", true);
        }
    }
}
