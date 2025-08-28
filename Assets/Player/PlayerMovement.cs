using System.Threading.Tasks;
using Movements;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        private bool _isAttacking;
        private bool _jumpWasTriggered;
        private Vector2 _moveInput;

        private Movement _movement;

        private void Start()
        {
            _movement = new Movement(characterController);

            ServiceLocator<InputHandler>.Service.MoveAction += OnMove;
            ServiceLocator<InputHandler>.Service.JumpActionTriggered += OnJumpTriggered;
            ServiceLocator<PlayerController>.Service.AttackStarted += OnAttackStarted;
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

        private void OnAttackStarted()
        {
            if (_isAttacking) return;

            TaskHelper.Run(StartAttack(), EndAttack);
        }

        private async Task StartAttack()
        {
            _isAttacking = true;

            var firstPosition = transform.position + transform.forward;
            var secondPosition = transform.position;

            await WaitForMovement(firstPosition);
            await WaitForMovement(secondPosition);
        }

        private async Task WaitForMovement(Vector3 firstPosition)
        {
            while (true)
            {
                var offset = firstPosition - transform.position;
                if (offset.magnitude < 0.2f) break;

                offset = offset.normalized * ServiceLocator<PlayerAttributes>.Service.attackSpeed;
                _movement.Move(offset * Time.deltaTime);

                await Task.Delay(1);
            }
        }

        private void EndAttack()
        {
            _isAttacking = false;
            ServiceLocator<PlayerController>.Service.EndAttack();
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