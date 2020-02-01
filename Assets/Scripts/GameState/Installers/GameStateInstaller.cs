using UnityEngine;
using Zenject;

namespace GameState.Installers {
    public class GameStateInstaller : MonoInstaller {
#pragma warning disable 649
        [SerializeField]
        private GameObject _gameStateController;
        
        [SerializeField]
        private GameStateSettings _gameStateSettings;
#pragma warning restore 649
        
        public override void InstallBindings() {
            // Settings
            Container.Bind<GameStateSettings>().FromInstance(_gameStateSettings).AsSingle();
            
            // We use "WithId" here so we can inject a specific animator to the interested parties.
            Container.Bind<Animator>().WithId("GameStateController").FromComponentInNewPrefab(_gameStateController).AsSingle();
            Container.Bind<IInitializable>().To<GameStateControllerInitializer>().AsSingle();

            // This is mutable and globally accessible for simplicity, but we should really only allow certain
            // states to mutate and return context data.
            Container.Bind<GameContext>().AsSingle();
            
            // Game State Container Registry injections
            Container.Bind<GameStateContainerRegistry>().AsSingle().WhenInjectedInto<GameStateContainerRegistryInstaller>();
            Container.Install<GameStateContainerRegistryInstaller>();
        }
    }
}