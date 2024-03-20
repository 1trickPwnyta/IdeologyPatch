using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace IdeologyPatch.RoleChangeUseUntaken
{
    [HarmonyPatch(typeof(Dialog_BeginRitual))]
    [HarmonyPatch("UpdateRoleChangeTargetRole")]
    public static class Patch_Dialog_BeginRitual_UpdateRoleChangeTargetRole
    {
        public static void Postfix(Dialog_BeginRitual __instance, Pawn p)
        {
            Ideo ideo = p.Ideo;
            if ((ideo != null ? ideo.GetRole(p) : null) == null)
            {
                Precept_Role roleToChangeTo = RitualUtility.AllRolesForPawn(p).FirstOrDefault(role => 
                    role.Active && 
                    role.RequirementsMet(p) && 
                    !PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_FreeColonists.Any(pawn => role.IsAssigned(pawn))
                );
                if (roleToChangeTo != null)
                {
                    __instance.SetRoleToChangeTo(roleToChangeTo);
                }
            }
        }
    }
}
