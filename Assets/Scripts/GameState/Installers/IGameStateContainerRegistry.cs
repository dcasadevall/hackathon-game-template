using System.Collections.Generic;
using Zenject;

namespace GameState.Installers {
    /// <summary>
    /// This registry can be used to allow injecting game states "bottom up".
    /// It keeps track of all contexts relevant to game states.
    /// It should only be known to GameStateMachineBehaviour.
    /// </summary>
    public interface IGameStateContainerRegistry {
        IEnumerable<DiContainer> Containers { get; }
    }
}