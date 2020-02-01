using GameState;
using GameState.Installers;

namespace GameInProgress {
    /// <summary>
    /// Installs states that drive the game in progress.
    /// This whole namespace is a bit of a placeholder, as games will normally just have different states during
    /// the game itself.
    /// </summary>
    internal class GameInProgressStateInstaller : AbstractGameStateInstaller {
        protected override void InstallGameStateBindings() {
            Container.Bind<IGameState>().To<GameInProgressState>().AsSingle();
        }
    }
}