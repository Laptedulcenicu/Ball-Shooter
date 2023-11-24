using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private SizeSetter sizeSetter;
        [SerializeField] private PlayerShoot playerShoot;

        public PlayerShoot PlayerShoot => playerShoot;

        public SizeSetter SizeSetter => sizeSetter;
    }
}