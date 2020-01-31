namespace GameState {
    public delegate void StateTransitionDelegate(TransitionType transitionType);
    
    /// <summary>
    /// GameState to be used as a building block for our game.
    /// </summary>
    public interface IGameState {
        event StateTransitionDelegate TransitionTriggered;

        void HandleStateEntered();
        void HandleStateUpdate();
        void HandleStateExit();
    }
}