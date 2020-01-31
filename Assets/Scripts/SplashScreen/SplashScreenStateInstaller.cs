using GameState;
using GameState.Installers;

namespace SplashScreen {
    public class SplashScreenStateInstaller : AbstractGameStateInstaller {
        protected override void InstallGameStateBindings() {
            Container.Bind<IGameState>().To<SplashScreenState>().AsSingle();
        }
    }
}