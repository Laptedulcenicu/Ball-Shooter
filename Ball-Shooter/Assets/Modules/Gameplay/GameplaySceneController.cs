using System.Collections.Generic;
using Modules.Common;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    [SerializeField] private Transform playerMarker;
    [SerializeField] private Transform gateMarker;
    [SerializeField] private Transform lineViewMarker;
    [SerializeField] private Transform[] enemiesMarkers;

    public GameObject Player { get; set; }
    public GameObject Gate { get; set; }
    public GameObject LineView { get; set; }
    public List<GameObject> Enemies { get; set; } = new();
    public GameObject UI { get; set; }

    public Transform PlayerMarker => playerMarker;

    public Transform GateMarker => gateMarker;

    public Transform LineViewMarker => lineViewMarker;

    public Transform[] EnemiesMarkers => enemiesMarkers;


    public void Initialize(ISceneTransitionService sceneTransitionService)
    {
        sceneTransitionService.FadeOut();
    }
}