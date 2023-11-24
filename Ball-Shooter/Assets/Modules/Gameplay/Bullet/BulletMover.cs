using UnityEngine;

namespace Modules.Gameplay
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float speedMove=2;

        private bool _isMoving;

        private void Update()
        {
            if (_isMoving)
            {
                transform.position += transform.forward * (Time.deltaTime * speedMove);
            }
        }

        public void Move()
        {
            _isMoving = true;
        }

        public void StopMove()
        {
            _isMoving = false;
        }
    }
}