using Commons;
using Movements;
using UnityEngine;
using UnityEngine.AI;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private bool _isAttacking;
        private bool _jumpWasTriggered;
        private Vector2 _moveInput;

        private IMovement _movement;

        private void Start()
        {
            _movement = new NavMeshAgentMovement(GetComponent<NavMeshAgent>());

            ServiceLocator<InputHandler>.Service.MoveAction += OnMove;
            ServiceLocator<InputHandler>.Service.JumpActionTriggered += OnJumpTriggered;
        }

        private void Update()
        {
            if (_isAttacking) return;

            _movement.ResetVelocityY();
            if (ShouldJump())
                Jump();
            _movement.ApplyGravity();
            Move();
        }

        private void OnJumpTriggered()
        {
            _jumpWasTriggered = true;
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

        private bool ShouldJump()
        {
            return _jumpWasTriggered && _movement.CanJump();
        }

        private void Jump()
        {
            _movement.Jump(ServiceLocator<PlayerAttributes>.Service.jumpStrength);
            _jumpWasTriggered = false;
        }

        private void Move()
        {
            var move = GetMoveInputValue();
            var playerMovementSpeed = ServiceLocator<PlayerAttributes>.Service.movementSpeed;
            _movement.UpdatePosition(move, playerMovementSpeed);
        }
    }
}