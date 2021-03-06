using System.Collections.Generic;
using GameState.Installers;
using LogSystem;
using UnityEngine;
using Util.ClassTypeReference;
using Zenject;
using ILogger = LogSystem.ILogger;

namespace GameState {
    /// <summary>
    /// Game State Machine Behaviour that controls the execution of <see cref="IGameState"/>s.
    /// This class should not change much, as it is simply the glue from state machine behaviours to
    /// game states.
    /// </summary>
    public class GameStateMachineBehaviour : StateMachineBehaviour {
#pragma warning disable 649
        [SerializeField]
        [ClassImplements(typeof(IGameState), Grouping = ClassGrouping.None)]
        private ClassTypeReference _gameStateType;
#pragma warning restore 649

        private IGameState _gameState;
        private Animator _animator;
        private IGameStateContainerRegistry _gameStateContainerRegistry;
        private ILogger _logger;

        [Inject]
        public void Construct(IGameStateContainerRegistry gameStateContainerRegistry, ILogger logger) {
            _gameStateContainerRegistry = gameStateContainerRegistry;
            _logger = logger;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            // We can't rely on state enter, because it can happen before zenject bindings on scene load, so we
            // have to keep trying to initialize on update.
            InitializeStateIfNecessary(animator);

            _gameState?.HandleStateUpdate();
        }

        private void InitializeStateIfNecessary(Animator animator) {
            if (_gameState != null) {
                return;
            }
            
            AssignGameState();
            
            // This can happen right after entering a scene. GameStateMachineBehaviours trigger OnEnter
            // BEFORE zenject bindings happen. This is why we keep calling InitializeStateIfNecessary every update.
            if (_gameState == null) {
                return;
            }
            
            Debug.Log($"Entering State: {_gameStateType}");
            _animator = animator;
            _gameState.TransitionTriggered += HandleTransitionTriggered;
            _gameState.HandleStateEntered();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            if (_gameState == null) {
                _logger.LogError(LoggedFeature.GameState, $"Game State not found for state {_gameStateType}");
                return;
            }
            
            Debug.Log($"Exiting State: {_gameStateType}");
            _gameState.HandleStateExit();
            _gameState = null;
        }

        private void HandleTransitionTriggered(TransitionType transitionType) {
            _gameState.TransitionTriggered -= HandleTransitionTriggered;
            // This may be true if we are closing the game, which cancels all async processes.
            if (_animator == null) {
                return;
            }
            
            _animator.SetBool(transitionType.ToString(), true);
        }

        // This is necessary because project context needs to hold the game state logic, but we don't want to
        // have to inject all states in project context. Instead, we want a " bottom up " approach.
        // This means that the project context container does not have the state bindings.
        private void AssignGameState() {
            foreach (var container in _gameStateContainerRegistry.Containers) {
                if (!container.HasBinding(typeof(IGameState))) {
                    continue;
                }

                var gameStates = container.Resolve<IGameState[]>();
                foreach (var gameState in gameStates) {
                    if (gameState.GetType() == _gameStateType.Type) {
                        _gameState = (IGameState) container.Instantiate(_gameStateType.Type);
                        break;
                    }
                }
                
            }
        }
    }
}