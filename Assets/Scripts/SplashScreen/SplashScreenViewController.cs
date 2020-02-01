using System.Threading.Tasks;
using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace SplashScreen {
	/// <summary>
	/// MonoBehaviour implementation of <see cref="ISplashScreenViewController"/>.
	/// </summary>
	internal class SplashScreenViewController : MonoBehaviour, ISplashScreenViewController {
#pragma warning disable 649
		[SerializeField]
		private Button _startButton;
#pragma warning restore 649

    private void Awake() {
	    Preconditions.CheckNotNull(_startButton);
    }

		public async UniTask Show() {
			gameObject.SetActive(true);
			await _startButton.OnClickAsync();
			gameObject.SetActive(false);
		}
	}
}
