using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Gameplay
{
    public class OpenDoorTrigger : MonoBehaviour, IInteractable
    {
        [FormerlySerializedAs("gate")] [SerializeField] private GateView gateView;
        private bool _isInteracted;

        public void Interact()
        {
            if (!_isInteracted)
            {
                _isInteracted = true;
                gateView.OpenDoor();
            }
        }
    }
}