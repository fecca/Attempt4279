using Movements;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private Vector2 _moveInput;

        private IMovement _movement;
        private PlayerAttributes _playerAttributes;

        private void Start()
        {
            _movement = new CharacterControllerMovement(GetComponent<CharacterController>());
            _inputHandler.MoveAction += OnMove;
        }

        private void Update()
        {
            Move();
        }

        [Inject]
        public void Construct(PlayerInputHandler inputHandler, PlayerAttributes playerAttributes)
        {
            _playerAttributes = playerAttributes;
            _inputHandler = inputHandler;
        }

        private void OnMove(Vector2 moveInput)
        {
            _moveInput = moveInput;
        }

        private void Move()
        {
            var playerMovementSpeed = _playerAttributes.movementSpeed;
            _movement.Move(_moveInput, playerMovementSpeed);
        }
    }
}