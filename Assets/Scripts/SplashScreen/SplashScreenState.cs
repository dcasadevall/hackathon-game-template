using Audio;
using GameState;
using Zenject;

namespace SplashScreen {
    /// <summary>
    /// State Responsible for showing / hiding the splash screen, as well as advancing to the game scene when the
    /// start button is pressed.
    /// </summary>
    public class SplashScreenState : IGameState {
        public event StateTransitionDelegate TransitionTriggered;

        private readonly ISplashScreenViewController _splashScreenViewController;
        private readonly IAudioPlayer _audioPlayer;
        private readonly GameStateSettings _gameStateSettings;
        private readonly ZenjectSceneLoader _sceneLoader;

        public SplashScreenState(ISplashScreenViewController splashScreenViewController,
                                 IAudioPlayer audioPlayer,
                                 GameStateSettings gameStateSettings,
                                 ZenjectSceneLoader sceneLoader) {
            _splashScreenViewController = splashScreenViewController;
            _audioPlayer = audioPlayer;
            _gameStateSettings = gameStateSettings;
            _sceneLoader = sceneLoader;
        }

        public async void HandleStateEntered() {
            _audioPlayer.PlayMusic(MusicType.SplashScreenMusic);

            await _splashScreenViewController.Show().SuppressCancellationThrow();

            TransitionTriggered?.Invoke(TransitionType.SplashScreenButtonPressed);
        }

        public void HandleStateUpdate() { }

        public void HandleStateExit() {
            _sceneLoader.LoadScene(_gameStateSettings.GameScene);
        }
    }
}