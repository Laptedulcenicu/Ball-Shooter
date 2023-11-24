using UnityEngine;

namespace Modules.Gameplay
{
    public class BulletView: MonoBehaviour
    {
        [SerializeField] private SizeSetter sizeSetter;
        [SerializeField] private BulletMover _bulletMover;

        public SizeSetter SizeSetter => sizeSetter;

        public BulletMover BulletMover => _bulletMover;
    }
}