using Audio;
using GameState;
using LifecycleStates;
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
    private readonly LifecycleStateSettings _lifecycleStateSettings;
    private readonly ZenjectSceneLoader _sceneLoader;

    public SplashScreenState(ISplashScreenViewController splashScreenViewController,
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
      _audioPlayer.PlayMusic(MusicType.SplashScreenMusic);
    }

    public void HandleStateUpdate() { }

    public void HandleStateExit() {
      _splashScreenViewController.StartButtonPressed -= HandleStartButtonPressed;
      _splashScreenViewController.Hide();
    }

    private void HandleStartButtonPressed() {
      _splashScreenViewController.StartButtonPressed -= HandleStartButtonPressed;
      _sceneLoader.LoadScene(_lifecycleStateSettings.GameScene);

      TransitionTriggered?.Invoke(TransitionType.SplashScreenButtonPressed);
    }
  }
}