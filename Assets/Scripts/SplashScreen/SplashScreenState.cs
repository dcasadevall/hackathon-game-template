using Audio;
using GameState;
using LogSystem;
using Networking;
using UniRx.Async;
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
        private readonly INetworkManager _networkManager;
        private readonly ILogger _logger;
        private readonly GameStateSettings _gameStateSettings;
        private readonly ZenjectSceneLoader _sceneLoader;

        public SplashScreenState(ISplashScreenViewController splashScreenViewController,
                                 IAudioPlayer audioPlayer,
                                 INetworkManager networkManager,
                                 ILogger logger,
                                 GameStateSettings gameStateSettings,
                                 ZenjectSceneLoader sceneLoader) {
            _splashScreenViewController = splashScreenViewController;
            _audioPlayer = audioPlayer;
            _networkManager = networkManager;
            _logger = logger;
            _gameStateSettings = gameStateSettings;
            _sceneLoader = sceneLoader;
        }

        public async void HandleStateEntered() {
            _audioPlayer.PlayMusic(MusicType.SplashScreenMusic);

            _logger.Log(LoggedFeature.Network, "Connecting to room..");
            UniTask.WaitUntil(() => _networkManager.IsConnected);
            _logger.Log(LoggedFeature.Network, "Connected to room.");
            await _splashScreenViewController.Show().SuppressCancellationThrow();

            TransitionTriggered?.Invoke(TransitionType.SplashScreenButtonPressed);
        }

        public void HandleStateUpdate() { }

        public void HandleStateExit() {
            _sceneLoader.LoadScene(_gameStateSettings.GameScene);
        }
    }
}