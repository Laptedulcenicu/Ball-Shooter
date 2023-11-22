using Modules.Common;
using Modules.Core.Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Core
{
    public class LoadLevelState : IState
    {
        private const string k_SceneName = "Gameplay";

        private readonly IUIFactory _uiFactory;
        private readonly IAudioService _audioService;
        private readonly ISceneFactory _sceneFactory;
        private readonly ISceneTransitionService _transitionService;
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(IAudioService audioService, ISceneFactory sceneFactory, IUIFactory uiFactory,
            ISceneTransitionService sceneTransitionService, GameStateMachine gameStateMachine)
        {
            _uiFactory = uiFactory;
            _audioService = audioService;
            _sceneFactory = sceneFactory;
            _transitionService = sceneTransitionService;
            _gameStateMachine = gameStateMachine;
        }


        public void Enter()
        {
            _audioService.PlayMusic();
            _transitionService.ChangeScene(k_SceneName, SceneLoaded);
        }

        private void SceneLoaded()
        {
            var scene = SceneManager.GetActiveScene();
            var sceneController = scene.GetComponent<GameplaySceneController>();
            
            InitScene(sceneController);
            InitUI(sceneController);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitUI(GameplaySceneController sceneController)
        {
            var ui = _uiFactory.CreateUI();
            sceneController.UI = ui;
        }

        private void InitScene(GameplaySceneController sceneController)
        {
            InitPlayer(sceneController);
            InitLineView(sceneController);
            InitGate(sceneController);
            InitEnemies(sceneController);
        }

        private void InitPlayer(GameplaySceneController sceneController)
        {
            var player = _sceneFactory.CreatePlayer();
            sceneController.Player = player;
            InitObject(player.transform, sceneController.PlayerMarker);
        }


        private void InitLineView(GameplaySceneController sceneController)
        {
            var lineView = _sceneFactory.CreateLineView();
            sceneController.LineView = lineView;
            InitObject(lineView.transform, sceneController.LineViewMarker);
        }

        private void InitGate(GameplaySceneController sceneController)
        {
            var gate = _sceneFactory.CreateGate();
            sceneController.Gate = gate;
            InitObject(gate.transform, sceneController.GateMarker);
        }

        private void InitEnemies(GameplaySceneController sceneController)
        {
            foreach (var sceneControllerEnemiesMarker in sceneController.EnemiesMarkers)
            {
                var currentEnemy = _sceneFactory.CreateEnemy();
                sceneController.Enemies.Add(currentEnemy);
                InitObject(currentEnemy.transform, sceneControllerEnemiesMarker);
            }
        }

        private void InitObject(Transform currentObject, Transform marker)
        {
            currentObject.position = marker.position;
            currentObject.eulerAngles = marker.eulerAngles;
            currentObject.transform.SetParent(marker);
        }
    }
}