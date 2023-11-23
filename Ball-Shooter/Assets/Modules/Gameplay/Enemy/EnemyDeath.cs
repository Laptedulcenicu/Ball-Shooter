using DG.Tweening;
using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private GameObject deathFx;
        [SerializeField] private Collider enemyCollider;
        [SerializeField] private EnemyAnimator enemyAnimator;

        private IAudioService _audioService;

        private bool _isDeath;

        public void Initialize(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void Die()
        {
            if (_isDeath) return;
            enemyCollider.enabled = false;
            enemyAnimator.PlayDeath();
            DOVirtual.DelayedCall(1, ActivateFX);
        }

        private void ActivateFX()
        {
            //  Instantiate(deathFx, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}