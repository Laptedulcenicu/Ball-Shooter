﻿using StansAssets.Foundation.Patterns;
using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Transform bulletParent;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float minBulletSize = 0.2f;

        private PrefabPool _bulletPool;
        private BulletView _currentActiveBullet;
        private KilledEnemyChecker _killedEnemyChecker;
        private const float k_SizeDeathZoneMultiplayer = 1.03f;

        public BulletView CurrentActiveBullet => _currentActiveBullet;

        public void Initialize(KilledEnemyChecker killedEnemyChecker)
        {
            _bulletPool = new PrefabPool(bulletPrefab);
            _killedEnemyChecker = killedEnemyChecker;
        }

        public void InitializeBullet()
        {
            _currentActiveBullet = GetBullet();
            _currentActiveBullet.Initialize(_killedEnemyChecker, _bulletPool);
            
            _currentActiveBullet.transform.position = bulletParent.position;
            _currentActiveBullet.transform.eulerAngles = bulletParent.eulerAngles;
            _currentActiveBullet.SizeSetter.TransformModel.localScale = Vector3.zero;
        }

        public void ChangeBulletSize(float sizeAmount)
        {
            if (_currentActiveBullet == null)
            {
                InitializeBullet();
            }

            _currentActiveBullet.SizeSetter.ChangeCurrentSize(sizeAmount);
            _currentActiveBullet.DeathZone.ChangeDeathZoneSize(sizeAmount * k_SizeDeathZoneMultiplayer);
        }

        public void Shoot()
        {
            _currentActiveBullet.BulletMover.Move();
            _currentActiveBullet = null;
        }

        public bool CanShoot()
        {
            return _currentActiveBullet.SizeSetter.TransformModel.localScale.x >= minBulletSize;
        }

        private BulletView GetBullet()
        {
            return _bulletPool.Get().GetComponent<BulletView>();
        }
    }
}