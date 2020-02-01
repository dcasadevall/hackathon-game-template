using UniRx.Async;

namespace GameOverScreen {
    /// <summary>
    /// Implementors of this interface will be responsible for showing / hiding a gameOver screen.
    /// </summary>
    public interface IGameOverScreenViewController {
        /// <summary>
        /// Shows the view controller and completes the asynchronous task once it is dismissed.
        /// </summary>
        /// <returns></returns>
        UniTask Show();
    }
}