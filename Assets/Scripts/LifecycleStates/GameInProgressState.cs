using GameState;

namespace LifecycleStates {
    /// <summary>
    /// Placeholder state for use while the game is in progress.
    /// If you wish to use the <see cref="IGameState"/> system for things other than application lifecycle,
    /// you will most likely not have a "game in progress" state, and instead have smaller substates for the
    /// actual game state.
    /// </summary>
    public class GameInProgressState : IGameState {
        public event StateTransitionDelegate TransitionTriggered;
        
        public void HandleStateEntered() {
        }

        public void HandleStateUpdate() {
        }

        public void HandleStateExit() {
        }
    }
}