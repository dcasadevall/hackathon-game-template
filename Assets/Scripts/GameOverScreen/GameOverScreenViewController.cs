using UniRx.Async;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GameOverScreen {
	/// <summary>
	/// MonoBehaviour implementation of <see cref="IGameOverScreenViewController"/>.
	/// </summary>
	internal class GameOverScreenViewController : MonoBehaviour, IGameOverScreenViewController {
#pragma warning disable 649
		[SerializeField]
		private Button _restartButton;
#pragma warning restore 649

    // Hide on awake since the Monobehaviour is instantiated when injected.
    private void Awake() {
	    Preconditions.CheckNotNull(_restartButton);
    }

		public async UniTask Show() {
			gameObject.SetActive(true);
			await _restartButton.OnClickAsync();
			gameObject.SetActive(false);
		}
	}
}
