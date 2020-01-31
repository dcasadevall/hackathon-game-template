using Zenject;

namespace GameState.Installers {
    /// <summary>
    /// This installer should be used when binding commands on an installer that will be used in scene contexts.
    /// It ensures that the <see cref="IGameStateFactory"/> has visibility over the scene context in order to resolve
    /// such game states.
    /// </summary>
    public abstract class AbstractGameStateInstaller : Installer {
        private GameStateContainerRegistry _gameStateContainerRegistry;

        [Inject]
        public void Construct(GameStateContainerRegistry gameStateContainerRegistry) {
            _gameStateContainerRegistry = gameStateContainerRegistry;
        }
        
        // This should NOT be called in the base method
        public override void InstallBindings() {
            _gameStateContainerRegistry.RegisterSceneContainer(Container);
            
            InstallGameStateBindings();
        }

        protected abstract void InstallGameStateBindings();
    }
}