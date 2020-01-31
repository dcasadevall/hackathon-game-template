using GameState;
using UnityEngine;
using Zenject;

namespace SplashScreen {
    /// <summary>
    /// Installer used for Splash Screen UI bindings
    /// </summary>
    public class SplashScreenInstaller : MonoInstaller {
#pragma warning disable 649
        [SerializeField]
        private GameObject _splashScreenPrefab;
#pragma warning restore 649
        
        public override void InstallBindings() {
            Container.Bind<ISplashScreenViewController>().To<SplashScreenViewController>()
                     .FromComponentInNewPrefab(_splashScreenPrefab).AsSingle().Lazy();
            
            Container.Install<SplashScreenStateInstaller>();
        }
    }
}