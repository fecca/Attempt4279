using Movements;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private const int MaxHealth = 3;
        private int _currentHealth;
        private bool _isBeingAttacked;

        private IMovement _movement;

        private void Awake()
        {
            _currentHealth = MaxHealth;
            _movement = new NavMeshAgentMovement(GetComponent<NavMeshAgent>());
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