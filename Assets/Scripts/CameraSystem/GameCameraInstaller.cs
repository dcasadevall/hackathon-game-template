using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CameraSystem {
    /// <summary>
    /// Installer used to inject both the <see cref="Camera"/> and <see cref="EventSystem"/> to the project.
    /// This is useful to avoid having multiple different cameras being used throughout the game when only one is
    /// needed.
    /// 
    /// If you want to use a camera per scene instead, you can avoid using this installer, and instead
    /// place the cameras directly into the desired scenes.
    /// Note that if you do that, you may need to handle camera lifecycle yourself since scenes may be
    /// loaded asynchronously.
    /// </summary>
    public class GameCameraInstaller : MonoInstaller {
#pragma warning disable 649
        [SerializeField]
        private GameObject _cameraPrefab;
#pragma warning restore 649
        
        public override void InstallBindings() {
            Container.Bind<CameraInput>().AsSingle();
            Container.Bind(typeof(Camera), typeof(EventSystem)).FromComponentInNewPrefab(_cameraPrefab)
                     .AsSingle()
                     .NonLazy();
        }
    }
}