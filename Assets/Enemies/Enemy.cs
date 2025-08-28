using System.Collections;
using Movements;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private const int MaxHealth = 3;
        private const float MovementSpeed = 4.0f;

        [SerializeField] private CharacterController characterController;
        private int _currentHealth;
        private bool _isBeingAttacked;

        private Movement _movement;
        private bool _wasAttacked;

        private void Awake()
        {
            _currentHealth = MaxHealth;
        }

        private void Start()
        {
            _movement = new Movement(characterController);
        }

        private void Update()
        {
            if (_isBeingAttacked) return;

            _movement.ApplyGravity();
            _movement.UpdatePosition();
        }

        public void OnAttacked(Vector3 attackerPosition)
        {
            if (_isBeingAttacked) return;

            _isBeingAttacked = true;
            StartCoroutine(RunAttackedSequence(attackerPosition));
        }

        private IEnumerator RunAttackedSequence(Vector3 attackerPosition)
        {
            var targetDirection = transform.position - attackerPosition;
            var targetPosition = transform.position + targetDirection;

            while (true)
            {
                var offset = targetPosition - transform.position;
                if (offset.magnitude < 0.2f) break;

                offset = offset.normalized * MovementSpeed;
                _movement.Move(offset * Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

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