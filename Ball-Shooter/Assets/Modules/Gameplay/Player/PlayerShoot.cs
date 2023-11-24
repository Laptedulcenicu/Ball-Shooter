using StansAssets.Foundation.Patterns;
using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform bulletParent;
        [SerializeField] private GameObject bulletPrefab;

        private PrefabPool _bulletPool;
        private BulletView _currentActiveBullet;

        private void Awake()
        {
            _bulletPool = new PrefabPool(bulletPrefab);
        }

        public void InitializeBullet()
        {
            _currentActiveBullet = _bulletPool.Get().GetComponent<BulletView>();
            _currentActiveBullet.transform.position = bulletParent.position;
        }

        public void ChangeBulletSize(float sizeAmount)
        {
            _currentActiveBullet.SizeSetter.ChangeCurrentSize(sizeAmount);
        }

        public void Shoot()
        {
            _currentActiveBullet.BulletMover.Move();
        }
    }
}