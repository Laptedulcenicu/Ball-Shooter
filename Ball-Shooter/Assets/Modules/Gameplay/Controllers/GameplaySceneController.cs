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
        public List<GameObject> Enemies { get; set; } = new();
        public GameObject UI { get; set; }

        public Transform PlayerMarker => playerMarker;

        public Transform GateMarker => gateMarker;

        public Transform LineViewMarker => lineViewMarker;

        public Transform[] EnemiesMarkers => enemiesMarkers;


        public void Initialize(IInputSource inputSource, ISceneTransitionService sceneTransitionService)
        {
            SetInputSource(inputSource);
            InitializeInteractableController(inputSource);
            sceneTransitionService.FadeOut();
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
    }
}