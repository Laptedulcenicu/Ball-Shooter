using Modules.Core;
using Modules.Services.AudioService;
using Modules.Services.LifecycleService;
using Modules.Services.SceneTransitionService;
using UnityEngine;

public class MasterSceneController : MonoBehaviour
{
    [SerializeField] private ApplicationObserver applicationObserver;
    [SerializeField] private SceneTransitionFadeController sceneTransitionFadeController;
    [SerializeField] private MusicController musicController;
    [SerializeField] private SoundController soundController;

    private void Awake()
    {
        var bootstrapper = new Bootstrapper(sceneTransitionFadeController, applicationObserver, musicController,
            soundController);
        bootstrapper.Initialize();
    }
}