using IdeologyPatch.RitualCooldownMessage;
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
            RitualCooldownUtility.ShowRitualCooldownMessageOnTick();
        }
    }
}
