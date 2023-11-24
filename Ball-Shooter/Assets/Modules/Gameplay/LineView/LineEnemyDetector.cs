using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Gameplay
{
    public class LineEnemyDetector : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;

        private readonly List<IInteractable> _enemyList = new();

        private void Awake()
        {
            triggerObserver.TriggerEnter += TriggerEnter;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                if (!other.TryGetComponent(out IInteractable interactable)) return;
                if (!_enemyList.Contains(interactable))
                {
                    _enemyList.Add(interactable);
                }
            }
        }

        public int ActiveEnemiesCount()
        {
            int count = _enemyList.Count(e => e.IsActive);
            return count;
        }
    }
}