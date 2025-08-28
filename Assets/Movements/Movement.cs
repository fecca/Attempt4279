using UnityEngine;

namespace Movements
{
    public class Movement
    {
        private readonly CharacterController _characterController;
        private Vector3 _playerVelocity;

        public Movement(CharacterController characterController)
        {
            _characterController = characterController;
        }

        public void ResetVelocityY()
        {
            if (_characterController.isGrounded && _playerVelocity.y < 0)
                _playerVelocity.y = 0f;
        }

        public bool CanJump()
        {
            return _characterController.isGrounded;
        }

        public void Jump(float jumpStrength)
        {
            _playerVelocity.y = Mathf.Sqrt(jumpStrength * -2.0f * Physics.gravity.y);
        }

        public void ApplyGravity()
        {
            _playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        public void UpdatePosition(Vector3 position = default, float movementSpeed = default)
        {
            var direction = position * movementSpeed
                            + _playerVelocity.y * Vector3.up;
            var finalPosition = direction * Time.deltaTime;

            Move(finalPosition);
        }

        public void Move(Vector3 position)
        {
            _characterController.Move(position);
        }
    }
}