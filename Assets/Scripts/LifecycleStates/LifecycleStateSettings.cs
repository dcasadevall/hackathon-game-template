using System;
using UnityEngine;

namespace LifecycleStates {
    [Serializable]
    public class LifecycleStateSettings {
        [SerializeField]
        private string _splashScreenScene = "SplashScreenScene";
        public string SplashScreenScene {
            get {
                return _splashScreenScene;
            }
        }

        [SerializeField]
        private string _gameScene = "GameScene";
        public string GameScene {
            get {
                return _gameScene;
            }
        }

        [SerializeField]
        private string _gameOverScene = "GameOverScene";
        public string GameOverScene {
            get {
                return _gameOverScene;
            }
        }
    }
}