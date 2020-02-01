using GameState;
using UnityEngine;
using Zenject;

namespace GameOverScreen {
    /// <summary>
    /// Installer used for Splash Screen UI bindings
    /// </summary>
    public class GameOverScreenInstaller : MonoInstaller {
#pragma warning disable 649
        [SerializeField]
        private GameObject _gameOverScreenPrefab;
#pragma warning restore 649
        
        public override void InstallBindings() {
            Container.Bind<IGameOverScreenViewController>().To<GameOverScreenViewController>()
                     .FromComponentInNewPrefab(_gameOverScreenPrefab).AsSingle().Lazy();
            
            Container.Install<GameOverScreenStateInstaller>();
        }
    }
}