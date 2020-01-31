using System.Collections.Generic;
using Zenject;

namespace GameState.Installers {
    /// <summary>
    /// This registry can be used to allow injecting game states "bottom up".
    /// It keeps track of all contexts relevant to game states.
    /// It should only be known to GameStateMachineBehaviour.
    /// </summary>
    public class GameStateContainerRegistry : IGameStateContainerRegistry {
        private readonly HashSet<DiContainer> _containers = new HashSet<DiContainer>();

        public IEnumerable<DiContainer> Containers {
            get {
                return _containers;
            }
        }

        public GameStateContainerRegistry(DiContainer container) {
            _containers.Add(container);
        }

        public void RegisterSceneContainer(DiContainer container) {
            _containers.Add(container);
        } 
    }
}