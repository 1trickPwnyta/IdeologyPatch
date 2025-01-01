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
        public static bool RecreationalDrugAvoidance = true;
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
        public static bool AllowGuestSlavePolicy = true;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();

            listingStandard.Begin(inRect);

            listingStandard.CheckboxLabeled("IdeologyPatch_DisableHumanFoodPlantThought".Translate(), ref DisableHumanFoodPlantThought);
            listingStandard.CheckboxLabeled("IdeologyPatch_DryadWanderRadius".Translate(), ref DryadWanderRadius);
            listingStandard.CheckboxLabeled("IdeologyPatch_PrisonerConversionLetterJumpToPrisoner".Translate(), ref PrisonerConversionLetterJumpToPrisoner);
            listingStandard.CheckboxLabeled("IdeologyPatch_PruningTime".Translate(), ref PruningTime);
            listingStandard.CheckboxLabeled("IdeologyPatch_RecreationalDrugAvoidance".Translate(), ref RecreationalDrugAvoidance);
            listingStandard.CheckboxLabeled("IdeologyPatch_ResearchMissingMemes".Translate(), ref ResearchMissingMemes);
            listingStandard.CheckboxLabeled("IdeologyPatch_RoleChangeUseUntaken".Translate(), ref RoleChangeUseUntaken);
            listingStandard.CheckboxLabeled("IdeologyPatch_BloodfeedingCorpsesDontCare".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref BloodfeedingCorpsesDontCare);
            listingStandard.CheckboxLabeled("IdeologyPatch_PremaritalSex".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref PremaritalSex);
            listingStandard.CheckboxLabeled("IdeologyPatch_FemaleNudity".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref FemaleNudity);
            listingStandard.CheckboxLabeled("IdeologyPatch_PantsOnly".Translate() + " " + "IdeologyPatch_RestartRequired".Translate(), ref PantsOnly);
            listingStandard.CheckboxLabeled("IdeologyPatch_FungusPreferredDisablesDarkThought".Translate(), ref FungusPreferredDisablesDarkThought);
            listingStandard.CheckboxLabeled("IdeologyPatch_DarklightDefault".Translate(), ref DarklightDefault);
            listingStandard.CheckboxLabeled("IdeologyPatch_RitualCooldownMessage".Translate(), ref RitualCooldownMessage);
            listingStandard.CheckboxLabeled("IdeologyPatch_LookChangeDesiredFix".Translate(), ref LookChangeDesiredFix);
            listingStandard.CheckboxLabeled("IdeologyPatch_NegativeApparelDesire".Translate(), ref NegativeApparelDesire);
            listingStandard.CheckboxLabeled("IdeologyPatch_RelicsCollectedNotAgain".Translate(), ref RelicsCollectedNotAgain);
            listingStandard.CheckboxLabeled("IdeologyPatch_ForbidArchonexusCorpses".Translate(), ref ForbidArchonexusCorpses);
            listingStandard.CheckboxLabeled("IdeologyPatch_FactionRelationAdjustment".Translate(), ref FactionRelationAdjustment);
            listingStandard.CheckboxLabeled("IdeologyPatch_AllowGuestSlavePolicy".Translate(), ref AllowGuestSlavePolicy);

            listingStandard.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref DisableHumanFoodPlantThought, "DisableHumanFoodPlantThought", true);
            Scribe_Values.Look(ref DryadWanderRadius, "DryadWanderRadius", true);
            Scribe_Values.Look(ref PrisonerConversionLetterJumpToPrisoner, "PrisonerConversionLetterJumpToPrisoner", true);
            Scribe_Values.Look(ref PruningTime, "PruningTime", true);
            Scribe_Values.Look(ref RecreationalDrugAvoidance, "RecreationalDrugAvoidance", true);
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
            Scribe_Values.Look(ref AllowGuestSlavePolicy, "AllowGuestSlavePolicy", true);
        }
    }
}
