using Zenject;

namespace LogSystem {
    public class LoggingInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<ILogger>().To<UnityLogger>().AsSingle();
        }
    }
}
