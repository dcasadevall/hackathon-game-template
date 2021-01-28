using Zenject;

namespace InputSystem {
    public class InputSystemInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IInputLock>().To<InputLock>().AsSingle();
            Container.Bind<IInputEvents>().To<InputEvents>().AsSingle();
        }
    }
}