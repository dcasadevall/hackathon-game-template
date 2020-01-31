using System;

namespace GameState {
    public interface IGameStateFactory {
        IGameState Create(Type gameStateType);
    }
}