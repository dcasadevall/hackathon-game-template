using UnityEngine;
using Zenject;

namespace LifecycleStates {
    public class LifecycleStatesInstaller : MonoInstaller {
#pragma warning disable 649
        [SerializeField]
        private LifecycleStateSettings _lifecycleStateSettings;
#pragma warning restore 649
        
        public override void InstallBindings() {
            Container.Bind<LifecycleStateSettings>().FromInstance(_lifecycleStateSettings).AsSingle();
            
            // We separate the game states into a non mono installer due to how game states are injected
            // in the game state controller.
            Container.Install<LifecycleGameStatesInstaller>();
        }
    }
}