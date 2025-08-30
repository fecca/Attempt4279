using Commons;
using Enemies;
using UnityEngine;

namespace Players
{
    public class PlayerCollision : MonoBehaviour
    {
        private bool _isEnabled;

        private void Start()
        {
            ServiceLocator<PlayerController>.Service.AttackStarted += OnAttackStarted;
            ServiceLocator<PlayerController>.Service.AttackEnded += OnAttackEnded;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_isEnabled) return;

            var enemy = other.transform.GetComponent<Enemy>();
            if (enemy == null) return;

            enemy.OnAttacked();
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