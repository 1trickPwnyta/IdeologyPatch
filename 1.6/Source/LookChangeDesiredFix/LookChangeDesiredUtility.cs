using LudeonTK;
using RimWorld;
using Verse;

namespace IdeologyPatch.LookChangeDesiredFix
{
    public static class LookChangeDesiredUtility
    {
#if DEBUG
        [DebugAction("Pawns", "Force look change desire", actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void ForceLookChangeDesire(Pawn p)
        {
            if (p.style.CanDesireLookChange && p.style.HasAnyUnwantedStyleItem)
            {
                p.style.RequestLookChange();
                p.style.nextStyleChangeAttemptTick = GenTicks.TicksGame;
            }
            else
            {
                Messages.Message(p.LabelShortCap + " is already happy with their look.", MessageTypeDefOf.RejectInput, false);
            }
        }
#endif
    }
}
