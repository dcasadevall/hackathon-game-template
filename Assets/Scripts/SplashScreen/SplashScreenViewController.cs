using System;
using UnityEngine;
using UnityEngine.UI;

namespace SplashScreen {
	/// <summary>
	/// MonoBehaviour implementation of <see cref="ISplashScreenViewController"/>.
	/// </summary>
	internal class SplashScreenViewController : MonoBehaviour, ISplashScreenViewController {
#pragma warning disable 649
		[SerializeField]
		private Button _startButton;
#pragma warning restore 649

		public event Action StartButtonPressed = delegate {};

    // Hide on awake since the Monobehaviour is instantiated when injected.
    private void Awake() {
        Hide();
    }

		private void Start() {
			if (_startButton == null) {
				Debug.LogError("Start button not assigned.");
				return;
			}
			
			_startButton.onClick.AddListener(HandleStartButtonPressed);
		}
		
		public void Show() {
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}

		private void HandleStartButtonPressed() {
			StartButtonPressed.Invoke();
		}
	}
}
