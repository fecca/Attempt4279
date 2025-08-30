using Commons;
using Movements;
using UnityEngine;
using UnityEngine.AI;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private bool _isAttacking;
        private Vector2 _moveInput;

        private IMovement _movement;

        private void Start()
        {
            _movement = new NavMeshAgentMovement(GetComponent<NavMeshAgent>());

            ServiceLocator<InputHandler>.Service.MoveAction += OnMove;
        }

        private void Update()
        {
            if (_isAttacking) return;

            Move();
        }

        private void OnMove(Vector2 moveInput)
        {
            _moveInput = moveInput;
        }

        private Vector3 GetMoveInputValue()
        {
            var moveVector = new Vector3(_moveInput.x, 0, _moveInput.y);
            moveVector = Vector3.ClampMagnitude(moveVector, 1f);
            if (moveVector != Vector3.zero) transform.forward = moveVector;

            return moveVector;
        }

        private void Move()
        {
            var move = GetMoveInputValue();
            var playerMovementSpeed = ServiceLocator<PlayerAttributes>.Service.movementSpeed;
            _movement.Move(move, playerMovementSpeed);
        }
    }
}