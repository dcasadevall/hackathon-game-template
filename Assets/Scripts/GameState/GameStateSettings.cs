using System;
using UnityEngine;

namespace GameState {
    [Serializable]
    public class GameStateSettings {
        [SerializeField]
        private string _splashScreenScene = "SplashScreen";
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
        private string _gameOverScene = "GameOverScreen";
        public string GameOverScene {
            get {
                return _gameOverScene;
            }
        }
    }
}