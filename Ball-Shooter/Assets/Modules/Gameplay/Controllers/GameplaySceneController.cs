using System;
using System.Collections.Generic;
using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GameplaySceneController : MonoBehaviour
    {
        [SerializeField] private Transform inputControllerParent;
        [SerializeField] private InteractableController interactableController;
        [SerializeField] private Transform playerMarker;
        [SerializeField] private Transform gateMarker;
        [SerializeField] private Transform lineViewMarker;
        [SerializeField] private Transform[] enemiesMarkers;

        private IInputController _inputController;
        public GameObject Player { get; set; }
        public GameObject Gate { get; set; }
        public GameObject LineView { get; set; }
        public List<EnemyDeath> Enemies { get; } = new();
        public IUIController UIController { get; set; }

        public Transform PlayerMarker => playerMarker;

        public Transform GateMarker => gateMarker;

        public Transform LineViewMarker => lineViewMarker;

        public Transform[] EnemiesMarkers => enemiesMarkers;


        public void Initialize(IInputSource inputSource, IAudioService audioService, Level level, ISceneTransitionService sceneTransitionService, Action onRestart)
        {
            SetInputSource(inputSource);
            InitializeInteractableController(inputSource);
            InitializeEnemies(audioService);
            InitializeSizeController();
            InitializeGameplayUI(level, onRestart);
            sceneTransitionService.FadeOut();
        }


        private void InitializeSizeController()
        {
        }

        private void InitializeEnemies(IAudioService audioService)
        {
            foreach (var enemy in Enemies)
            {
                enemy.Initialize(audioService);
            }
        }

        private void InitializeInteractableController(IInputSource inputSource)
        {
            interactableController.Initialize(inputSource);
        }

        private void SetInputSource(IInputSource inputSource)
        {
            _inputController = inputControllerParent.GetComponent<IInputController>();
            _inputController.Setup(inputSource);
        }

        private void InitializeGameplayUI(Level level, Action onRestart)
        {
            UIController.Initialize(level.CurrentLevel);
            UIController.OnRestart += onRestart;
            UIController.OnNextLevel += onRestart;
            UIController.OnPlay += Play;
        }

        private void Play()
        {
            interactableController.CanControl = true;
            UIController.Play();
        }
    }
}