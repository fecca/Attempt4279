using Commons;
using Movements;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector2 _moveInput;

        private IMovement _movement;
        private PlayerInputHandler _inputHandler;
        private PlayerAttributes _playerAttributes;

        [Inject]
        public void Construct(PlayerInputHandler inputHandler, PlayerAttributes playerAttributes)
        {
            _playerAttributes = playerAttributes;
            _inputHandler = inputHandler;
        }

        private void Start()
        {
            _movement = new CharacterControllerMovement(GetComponent<CharacterController>());
            _inputHandler.MoveAction += OnMove;
        }

        private void Update()
            => Move();

        private void OnMove(Vector2 moveInput)
            => _moveInput = moveInput;

        private void Move()
        {
            var playerMovementSpeed = _playerAttributes.movementSpeed;
            _movement.Move(_moveInput, playerMovementSpeed);
        }
    }
}