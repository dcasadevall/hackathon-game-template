
namespace SplashScreen {
    /// <summary>
    /// Implementors of this interface will be responsible for showing / hiding a splash screen that
    /// can be skipped by pressing a button.
    /// </summary>
    public interface ISplashScreenViewController {
        event System.Action StartButtonPressed;
        
        void Show();
        void Hide();
    }
}