using GameState;
using GameState.Installers;

namespace GameOverScreen {
    public class GameOverScreenStateInstaller : AbstractGameStateInstaller {
        protected override void InstallGameStateBindings() {
            Container.Bind<IGameState>().To<GameOverScreenState>().AsSingle();
        }
    }
}