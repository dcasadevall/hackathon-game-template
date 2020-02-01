using Audio;
using GameState;
using Zenject;

namespace GameOverScreen {
    /// <summary>
    /// State Responsible for showing / hiding the splash screen, as well as advancing to the game scene when the
    /// start button is pressed.
    /// </summary>
    public class GameOverScreenState : IGameState {
        public event StateTransitionDelegate TransitionTriggered;

        private readonly IGameOverScreenViewController _gameOverScreenViewController;
        private readonly IAudioPlayer _audioPlayer;
        private readonly GameStateSettings _gameStateSettings;
        private readonly ZenjectSceneLoader _sceneLoader;

        public GameOverScreenState(IGameOverScreenViewController gameOverScreenViewController,
                                   IAudioPlayer audioPlayer,
                                   GameStateSettings gameStateSettings,
                                   ZenjectSceneLoader sceneLoader) {
            _gameOverScreenViewController = gameOverScreenViewController;
            _audioPlayer = audioPlayer;
            _gameStateSettings = gameStateSettings;
            _sceneLoader = sceneLoader;
        }

        public async void HandleStateEntered() {
            _audioPlayer.PlayMusic(MusicType.GameOverMusic);

            await _gameOverScreenViewController.Show().SuppressCancellationThrow();

            TransitionTriggered?.Invoke(TransitionType.GameOver);
        }

        public void HandleStateUpdate() { }

        public void HandleStateExit() {
            _sceneLoader.LoadScene(_gameStateSettings.SplashScreenScene);
        }
    }
}