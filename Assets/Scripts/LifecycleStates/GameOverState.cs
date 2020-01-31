using Audio;
using GameState;
using SplashScreen;
using Zenject;

namespace LifecycleStates {
    /// <summary>
    /// State Responsible for showing / hiding the game over screen.
    /// TODO: Do not use splash screen view controller.
    /// </summary>
    public class GameOverState : IGameState {
        public event StateTransitionDelegate TransitionTriggered;

        private readonly ISplashScreenViewController _splashScreenViewController;
        private readonly IAudioPlayer _audioPlayer;
        private readonly LifecycleStateSettings _lifecycleStateSettings;
        private readonly ZenjectSceneLoader _sceneLoader;

        public GameOverState(ISplashScreenViewController splashScreenViewController,
                             IAudioPlayer audioPlayer,
                             LifecycleStateSettings lifecycleStateSettings,
                             ZenjectSceneLoader sceneLoader) {
            _splashScreenViewController = splashScreenViewController;
            _audioPlayer = audioPlayer;
            _lifecycleStateSettings = lifecycleStateSettings;
            _sceneLoader = sceneLoader;
        }

        public void HandleStateEntered() {
            _splashScreenViewController.StartButtonPressed += HandleStartButtonPressed;
            _splashScreenViewController.Show();
            _audioPlayer.PlayMusic(MusicType.GameOverMusic);
        }

        public void HandleStateUpdate() { }

        public void HandleStateExit() {
            _splashScreenViewController.StartButtonPressed -= HandleStartButtonPressed;
            _splashScreenViewController.Hide();
        }

        private void HandleStartButtonPressed() {
            _splashScreenViewController.StartButtonPressed -= HandleStartButtonPressed;
            _sceneLoader.LoadScene(_lifecycleStateSettings.SplashScreenScene);

            TransitionTriggered?.Invoke(TransitionType.RestartButtonPressed);
        }
    }
}