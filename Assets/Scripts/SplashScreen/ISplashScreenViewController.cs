using UniRx.Async;

namespace SplashScreen {
    /// <summary>
    /// Implementors of this interface will be responsible for showing / hiding a splash screen.
    /// </summary>
    public interface ISplashScreenViewController {
        /// <summary>
        /// Shows the view controller and completes the asynchronous task once it is dismissed.
        /// </summary>
        /// <returns></returns>
        UniTask Show();
    }
}