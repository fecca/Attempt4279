using Commons;
using Movements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private bool _isAttacking;
        private Vector2 _moveInput;
        public InputActionReference moveAction; // expects Vector2

        private IMovement _movement;

        private void OnEnable()
        {
            moveAction.action.Enable();
        }

        private void OnDisable()
        {
            moveAction.action.Disable();
        }

        private void Start()
        {
            // _movement = new NavMeshAgentMovement(GetComponent<NavMeshAgent>());
            _movement = new CharacterControllerMovement(GetComponent<CharacterController>());

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
            return moveAction.action.ReadValue<Vector2>();
            // var moveVector = new Vector3(_moveInput.x, 0, _moveInput.y);
            // moveVector = Vector3.ClampMagnitude(moveVector, 1f);
            // if (moveVector != Vector3.zero) transform.forward = moveVector;
            //
            // return moveVector;
        }

        private void Move()
        {
            var move = GetMoveInputValue();
            // var position = transform.position + Vector3.up * 5.0f + move;
            var playerMovementSpeed = ServiceLocator<PlayerAttributes>.Service.movementSpeed;
            _movement.Move(move, playerMovementSpeed);
        }
    }
}