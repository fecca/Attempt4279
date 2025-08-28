using Enemies;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private bool _isEnabled;

        private void Start()
        {
            ServiceLocator<PlayerController>.Service.AttackStarted += OnAttackStarted;
            ServiceLocator<PlayerController>.Service.AttackEnded += OnAttackEnded;
        }

        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!_isEnabled) return;

            var enemy = hit.transform.GetComponent<Enemy>();
            if (enemy == null) return;

            enemy.OnAttacked(transform.position);
        }

        private void OnAttackStarted()
        {
            _isEnabled = true;
        }

        private void OnAttackEnded()
        {
            _isEnabled = false;
        }
    }
}