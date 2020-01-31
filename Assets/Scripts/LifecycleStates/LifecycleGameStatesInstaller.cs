using GameState;
using GameState.Installers;
using SplashScreen;

namespace LifecycleStates {
    /// <summary>
    /// Installs states that drive the game lifecycle.
    /// </summary>
    internal class LifecycleGameStatesInstaller : AbstractGameStateInstaller {
        protected override void InstallGameStateBindings() {
            Container.Bind<IGameState>().To<GameInProgressState>().AsSingle();
            Container.Bind<IGameState>().To<GameOverState>().AsSingle();
        }
    }
}