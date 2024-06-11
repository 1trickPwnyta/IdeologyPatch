using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace IdeologyPatch.RoleChangeUseUntaken
{
    [HarmonyPatch(typeof(RitualRoleAssignments))]
    [HarmonyPatch(nameof(RitualRoleAssignments.UpdateRoleChangeTargetRole))]
    public static class Patch_RitualRoleAssignments_UpdateRoleChangeTargetRole
    {
        public static void Postfix(RitualRoleAssignments __instance, Pawn pawn)
        {
            if (IdeologyPatchSettings.RoleChangeUseUntaken)
            {
                Ideo ideo = pawn.Ideo;
                if ((ideo != null ? ideo.GetRole(pawn) : null) == null)
                {
                    Precept_Role roleToChangeTo = RitualUtility.AllRolesForPawn(pawn).FirstOrDefault(role =>
                        role.Active &&
                        role.RequirementsMet(pawn) &&
                        !PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists.Any(p => role.IsAssigned(p))
                    );
                    if (roleToChangeTo != null)
                    {
                        __instance.SetRoleChangeSelection(roleToChangeTo);
                    }
                }
            }
        }
    }
}
