using Zenject;

namespace GameState.Installers {
    public class GameStateContainerRegistryInstaller : Installer {
        private readonly GameStateContainerRegistry _registry;

        public GameStateContainerRegistryInstaller(GameStateContainerRegistry registry) {
            _registry = registry;
        }

        public override void InstallBindings() {
            Container.Bind<IGameStateContainerRegistry>()
                     .To<GameStateContainerRegistry>()
                     .FromInstance(_registry)
                     .WhenInjectedInto<GameStateMachineBehaviour>();

            Container.Bind<GameStateContainerRegistry>()
                     .FromInstance(_registry)
                     .When(context => context.ObjectType.IsSubclassOf(typeof(AbstractGameStateMonoInstaller)) ||
                                      context.ObjectType.IsSubclassOf(typeof(AbstractGameStateInstaller)));
        }
    }
}