using Zenject;

namespace GameInProgress {
    // This is extremely lame, but for now, all State installers need to be installed separately, and this installer
    // has no other bindings, so we end up with a MonoInstaller that just calls through to another installer.
    // This is only the case due to the fact that this "game in progress state" is in itself a bit of a placeholder.
    public class GameInProgressInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Install<GameInProgressStateInstaller>();
        } 
    }
}