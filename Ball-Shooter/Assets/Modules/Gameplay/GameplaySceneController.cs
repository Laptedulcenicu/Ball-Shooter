using Modules.Common;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private Transform characterSpawnPoint;
    [SerializeField] private Transform platformRoot;
    [SerializeField] private Transform inputController;


    public void Initialize(ISceneTransitionService sceneTransitionService)
    {
        sceneTransitionService.FadeOut();
    }
}