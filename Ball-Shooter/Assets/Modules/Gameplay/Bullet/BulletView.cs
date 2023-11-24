﻿using StansAssets.Foundation.Patterns;
using UnityEngine;

namespace Modules.Gameplay
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private BulletDeathZone bulletDeathZone;
        [SerializeField] private SizeSetter sizeSetter;
        [SerializeField] private BulletMover bulletMover;

        private KilledEnemyChecker _killedEnemyChecker;
        private PrefabPool _prefabPool;
        private bool _isTouched;
        public SizeSetter SizeSetter => sizeSetter;

        public BulletMover BulletMover => bulletMover;

        public BulletDeathZone DeathZone => bulletDeathZone;

        public void Initialize(KilledEnemyChecker killedEnemyChecker, PrefabPool prefabPool)
        {
            bulletMover.Initialize(killedEnemyChecker, prefabPool);
            _killedEnemyChecker = killedEnemyChecker;
            _prefabPool = prefabPool;
            bulletDeathZone.EnemyList.Clear();
            _isTouched = false;
            triggerObserver.TriggerEnter += TriggerEnter;
        }

        private void TriggerEnter(Collider other)
        {
            if (_isTouched) return;
            _isTouched = true;

            if (other.CompareTag(Tags.Enemy))
            {
                if (!other.TryGetComponent(out IInteractable _)) return;
                bulletDeathZone.KillEnemies();
                bulletMover.StopMove();
                _prefabPool.Release(gameObject);
                _killedEnemyChecker.CheckWinStatus();
            }
        }
    }
}