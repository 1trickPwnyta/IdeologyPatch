using RimWorld;
using System.Linq;
using UnityEngine;
using Verse;

namespace IdeologyPatch.FactionRelationAdjustment
{
    public static class FactionRelationUtility
    {
        public static void AdjustFactionRelations()
        {
            if (IdeologyPatchSettings.FactionRelationAdjustment)
            {
                foreach (Faction faction in Find.FactionManager.AllFactions.Where(f => !f.IsPlayer))
                {
                    FactionRelation relation = faction.RelationWith(Faction.OfPlayer);
                    if (relation.baseGoodwill > faction.NaturalGoodwill + 50)
                    {
                        relation.baseGoodwill = Mathf.Max(faction.NaturalGoodwill + 50, -100);
                    }
                }
            }
        }
    }
}
