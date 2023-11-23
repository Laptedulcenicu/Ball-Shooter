using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class InteractableController : MonoBehaviour
    {
        private IInputSource _inputSource;

        private InputEventData _inputEventData = new(false);
        public bool CanControl { get; set; }

        private void Update()
        {
            if (!CanControl)
                return;

            if (_inputEventData.IsTapDown)
            {
            }
        }

        private void OnDestroy() => RemoveInputListeners();


        public void Initialize(IInputSource inputSource)
        {
            _inputSource = inputSource;
            AddInputListeners();
        }

        private void InputSourceOnTapDown(InputEventData inputEventData) => _inputEventData = inputEventData;

        private void InputSourceOnDrop(InputEventData inputEventData) => _inputEventData = inputEventData;

        private void AddInputListeners()
        {
            _inputSource.OnTapDown += InputSourceOnTapDown;
            _inputSource.OnDrop += InputSourceOnDrop;
        }

        private void RemoveInputListeners()
        {
            _inputSource.OnTapDown -= InputSourceOnTapDown;
            _inputSource.OnDrop -= InputSourceOnDrop;
        }
    }
}