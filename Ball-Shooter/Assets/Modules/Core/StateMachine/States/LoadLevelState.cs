using Modules.Common;
using UnityEngine.SceneManagement;

namespace Modules.Core
{
    public class LoadLevelState : IState
    {
        private const string k_SceneName = "Gameplay";
        private readonly ISceneTransitionService _transitionService;
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(ISceneTransitionService sceneTransitionService,
            GameStateMachine gameStateMachine)
        {
            _transitionService = sceneTransitionService;
            _gameStateMachine = gameStateMachine;
        }


        public void Enter()
        {
            _transitionService.ChangeScene(k_SceneName, SceneLoaded);
        }

        private void SceneLoaded()
        {
            //   var uiController = GameObject.Instantiate(_applicationContext.Canvas).GetComponent<UIController>();
            //   var characterView = GameObject.Instantiate(_applicationContext.Player).GetComponent<CharacterView>();

            var scene = SceneManager.GetActiveScene();
            //  var sceneController = scene.GetComponent<GameplaySceneController>();
            //  sceneController.SetUIController(uiController);
            //  sceneController.SetCharacterView(characterView);

            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}