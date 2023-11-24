using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class InteractableController : MonoBehaviour
    {
        private const float k_SizeSpeedChange = 1;

        private IInputSource _inputSource;
        private SizeConverter _sizeConverter;
        private PlayerView _playerView;
        private InputEventData _inputEventData = new(false);

        public bool CanControl { get; set; }

        private void Update()
        {
            if (!CanControl)
                return;

            ChangeSize();
        }

        private void OnDestroy() => RemoveInputListeners();

        public void Initialize(IInputSource inputSource, SizeConverter sizeConverter, PlayerView playerView)
        {
            _sizeConverter = sizeConverter;
            _inputSource = inputSource;
            _playerView = playerView;
            CanControl = true;
            AddInputListeners();
        }

        private void ChangeSize()
        {
            if (_inputEventData.IsTapDown)
            {
                _sizeConverter.ChangeSize(Time.deltaTime * k_SizeSpeedChange);
            }
        }

        private void InputSourceOnTapDown(InputEventData inputEventData)
        {
            if (CanControl)
            {
                _playerView.PlayerShoot.InitializeBullet();
            }

            _inputEventData = inputEventData;
        }

        private void InputSourceOnDrop(InputEventData inputEventData)
        {
            _inputEventData = inputEventData;

            if (!CanControl) return;

            _playerView.PlayerShoot.Shoot();
            //   CanControl = false;
        }

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