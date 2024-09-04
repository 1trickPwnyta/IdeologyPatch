using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace IdeologyPatch
{
    public class GameComponent_IdeologyPatch : GameComponent
    {
        public GameComponent_IdeologyPatch(Game game)
        {
        }

        public override void GameComponentTick()
        {
            base.GameComponentTick();

            if (IdeologyPatchSettings.RitualCooldownMessage)
            {
                IEnumerable<Precept> precepts = Find.FactionManager.OfPlayer.ideos.AllIdeos.SelectMany(i => i.PreceptsListForReading.Where(p => p is Precept_Ritual));
                foreach (Precept precept in precepts)
                {
                    Precept_Ritual ritual = precept as Precept_Ritual;
                    if (ritual.isAnytime && ritual.lastFinishedTick != -1 && ritual.def.useRepeatPenalty && ritual.TicksSinceLastPerformed == 1200000)
                    {
                        Messages.Message("IdeologyPatch_RitualCanBePerformedAgain".Translate(ritual.LabelCap), MessageTypeDefOf.PositiveEvent);
                    }
                }
            }
        }
    }
}
