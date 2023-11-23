using DG.Tweening;
using UnityEngine;

namespace Modules.Gameplay
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private GameObject deathFx;
        [SerializeField] private Collider enemyCollider;
        [SerializeField] private EnemyAnimator enemyAnimator;

        private bool _isDeath;

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