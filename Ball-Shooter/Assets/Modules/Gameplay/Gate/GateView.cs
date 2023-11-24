using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GateView : MonoBehaviour, IInteractable
    {
        [SerializeField] private GateAnimator gateAnimator;
        [SerializeField] private float distance = 5;
        [SerializeField] private Transform openTriggerDoor;

        private IAudioService _audioService;
        private GameLoopEvents _gameLoopEvents;
        private bool _isInteracted;
        public bool IsActive => !_isInteracted;
        public void Initialize(IAudioService audioService, GameLoopEvents gameLoopEvents)
        {
            _gameLoopEvents = gameLoopEvents;
            _audioService = audioService;
            SetOpenTriggerDoorPosition();
        }

        private void SetOpenTriggerDoorPosition()
        {
            var forward = transform.forward;
            openTriggerDoor.transform.position = new Vector3(forward.x + distance, forward.y, forward.y);
        }

        public void OpenDoor()
        {
            //  _audioService.PlayOneShotSound();
            gateAnimator.OpenDoor();
        }



        public void Interact()
        {
            if (_isInteracted) return;
            
            _isInteracted = true;
            //  _audioService.PlayOneShotSound();
            _gameLoopEvents.OnWin?.Invoke();
        }
    }
}