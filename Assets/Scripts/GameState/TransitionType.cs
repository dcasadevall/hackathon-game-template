namespace GameState {
    /// <summary>
    /// Transitions that can happen from one state to another. These MUST match the parameter names triggering
    /// the transitions in the GameStateController Animator,
    /// </summary>
    public enum TransitionType {
        SplashScreenButtonPressed,
        GameOver,
        RestartButtonPressed
    }
}