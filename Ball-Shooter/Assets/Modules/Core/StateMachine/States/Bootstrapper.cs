using Modules.Common;
using Modules.Services.AudioService;
using Modules.Services.DataService;
using Modules.Services.InputService;
using Modules.Services.LifecycleService;
using Modules.Services.SceneTransitionService;

namespace Modules.Core
{
    public class Bootstrapper
    {
        private readonly SceneTransitionFadeController _fadeController;
        private readonly IApplicationObserver _applicationObserver;
        private readonly MusicController _musicController;
        private readonly SoundController _soundController;

        private GameStateMachine _gameStateMachine;
        private IInputService _inputService;
        private IDataService _dataService;
        private ILifecycleService _lifecycleService;
        private IAudioService _audioService;
        private ISceneTransitionService _sceneTransitionService;

        public Bootstrapper(SceneTransitionFadeController fadeController, IApplicationObserver applicationObserver, MusicController musicController, SoundController soundController)
        {
            _fadeController = fadeController;
            _applicationObserver = applicationObserver;
            _musicController = musicController;
            _soundController = soundController;
        }

        public void Initialize()
        {
            InitializeServices();

            _gameStateMachine = new GameStateMachine();
            AddStates();

            _audioService.PlayMusic();
            _gameStateMachine.Enter<LoadProgressDataState>();
        }

        private void AddStates()
        {
            var loadProgressDataState = new LoadProgressDataState(_dataService.ProgressData, _dataService.ApplicationCache, _lifecycleService, _gameStateMachine);
            var loadLevelState = new LoadLevelState(_dataService.ApplicationContext, _sceneTransitionService, _gameStateMachine);
            var gameLoopState = new GameLoopState(_dataService.ProgressData.Level, _inputService.InputSource, _audioService, _sceneTransitionService, _gameStateMachine);

            _gameStateMachine.States.Add(typeof(LoadProgressDataState), loadProgressDataState);
            _gameStateMachine.States.Add(typeof(LoadLevelState), loadLevelState);
            _gameStateMachine.States.Add(typeof(GameLoopState), gameLoopState);
        }

        private void InitializeServices()
        {
            _inputService = new InputService();
            _dataService = new DataService();
            _sceneTransitionService = new SceneTransitionService(_fadeController);
            _lifecycleService = new LifecycleService(_applicationObserver);
            _audioService = new AudioService(_musicController, _soundController);
        }
    }
}