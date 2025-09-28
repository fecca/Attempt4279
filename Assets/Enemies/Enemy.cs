using Movements;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private const int MaxHealth = 3;
        private const int PatrolRadius = 3;
        private int _currentHealth;
        private bool _isBeingAttacked;

        private IMovement _movement;

        private void Awake()
        {
            _currentHealth = MaxHealth;
            _movement = new NavMeshAgentMovement(GetComponent<NavMeshAgent>());
        }

        private void Update()
        {
            if (_movement.IsMoving()) return;

            var position = PickNewRandomPosition();
            _movement.Move(position);
        }

        private Vector3 PickNewRandomPosition()
        {
            var randomPosition = Random.insideUnitCircle * PatrolRadius;
            return transform.position + new Vector3(randomPosition.x, transform.position.y, randomPosition.y);
        }

        public void OnAttacked()
        {
            if (_isBeingAttacked) return;

            _isBeingAttacked = true;
            EndAttacked();
        }

        private void EndAttacked()
        {
            _isBeingAttacked = false;
            _currentHealth--;
            if (_currentHealth <= 0) Destroy(gameObject);
        }
    }
}