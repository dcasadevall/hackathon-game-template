using GameState;
using Zenject;

namespace GameInProgress {
    /// <summary>
    /// Placeholder state for use while the game is in progress.
    /// If you wish to use the <see cref="IGameState"/> system for things other than application lifecycle,
    /// you will most likely not have a "game in progress" state, and instead have smaller substates for the
    /// actual game state.
    ///
    /// For testing purposes, simply trigger the "GameOver" property in the animator in order to transition out
    /// of this state.
    /// </summary>
    public class GameInProgressState : IGameState {
        public event StateTransitionDelegate TransitionTriggered;
        
        private readonly GameStateSettings _gameStateSettings;
        private readonly ZenjectSceneLoader _sceneLoader;

        public GameInProgressState(GameStateSettings gameStateSettings, ZenjectSceneLoader sceneLoader) {
            _gameStateSettings = gameStateSettings;
            _sceneLoader = sceneLoader;
        }

        public void HandleStateEntered() {
        }

        public void HandleStateUpdate() {
        }

        public void HandleStateExit() {
            _sceneLoader.LoadScene(_gameStateSettings.GameOverScene);
        }
    }
}