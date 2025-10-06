using UnityEngine;

namespace Movements
{
    public class CharacterControllerMovement : IMovement
    {
        private readonly CharacterController _characterController;
        private bool _groundedPlayer;
        private Vector3 _playerVelocity;

        public CharacterControllerMovement(CharacterController characterController)
            => _characterController = characterController;

        public void Move(Vector3 direction = default, float movementSpeed = 1, float turnSpeed = 1)
        {
            _groundedPlayer = _characterController.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0) _playerVelocity.y = 0f;

            var move = new Vector3(direction.x, 0, direction.y);
            move = Vector3.ClampMagnitude(move, 1f);

            if (move != Vector3.zero)
                _characterController.transform.forward =
                    Vector3.Lerp(_characterController.transform.forward, move, Time.deltaTime * turnSpeed);

            _playerVelocity.y += -9.81f * Time.deltaTime;

            var finalMove = move * movementSpeed + _playerVelocity.y * Vector3.up;
            _characterController.Move(finalMove * Time.deltaTime);
        }

        public float GetVelocity()
            => new Vector2(_characterController.velocity.x, _characterController.velocity.z).magnitude;

        public bool IsMoving()
            => GetVelocity() > 0.0f;
    }
}