using Movements;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerMovement : MonoBehaviour
    {
        private static readonly int MovementSpeed = Animator.StringToHash("MovementSpeed");

        [SerializeField] private Animator animator;
        private PlayerInputHandler _inputHandler;
        private bool _isMoving;
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
            _movement.Move(_moveInput, _playerAttributes.movementSpeed, _playerAttributes.turnSpeed);
            animator.SetFloat(MovementSpeed, _movement.GetVelocity());
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
    }
}