using UnityEngine;
using Zenject;

namespace GameState {
    /// <summary>
    /// This class is necessary in order to force the Project Context to provide us with the game state
    /// controller animator (which instantiates it).
    ///
    /// TODO: Find a way to do this solely through the installer.
    /// </summary>
    internal class GameStateControllerInitializer : IInitializable {
        public GameStateControllerInitializer([Inject(Id="GameStateController")] Animator animator) {
        }
        
        public void Initialize() {
        }
    }
}