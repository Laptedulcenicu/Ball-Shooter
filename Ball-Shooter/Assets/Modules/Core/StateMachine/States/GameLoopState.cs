using System;
using Modules.Common;
using Modules.Core.Scripts.Utilities;
using Modules.Gameplay;
using UnityEngine.SceneManagement;

namespace Modules.Core
{
    public class GameLoopState : IState
    {
        private readonly Action _onRestart;
        private readonly ProgressData _progressData;
        private readonly IInputSource _inputSource;
        private readonly IAudioService _audioService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneTransitionService _sceneTransitionService;

        public GameLoopState(Level level, IInputSource inputSource, IAudioService audioService, ISceneTransitionService sceneTransitionService, GameStateMachine gameStateMachine)
        {
            //m_ProgressData = progressData;
            _inputSource = inputSource;
            _audioService = audioService;
            _gameStateMachine = gameStateMachine;
            _sceneTransitionService = sceneTransitionService;

            _onRestart += RestartLevel;
        }

        private void RestartLevel()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Enter()
        {
            var scene = SceneManager.GetActiveScene();
            var sceneController = scene.GetComponent<GameplaySceneController>();
            sceneController.Initialize(_inputSource,_sceneTransitionService);
        }
    }
}