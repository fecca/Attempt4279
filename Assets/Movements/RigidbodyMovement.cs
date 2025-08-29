using UnityEngine;

namespace Movements
{
    public class RigidbodyMovement : IMovement
    {
        private readonly Rigidbody _rigidbody;
        private Vector3 _playerVelocity;

        public RigidbodyMovement(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void ResetVelocityY()
        {
            if (IsGrounded() && _playerVelocity.y < 0)
                _playerVelocity.y = 0f;
        }

        public bool CanJump()
        {
            return IsGrounded();
        }

        public void Jump(float jumpStrength)
        {
            _rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

        public void ApplyGravity()
        {
            _rigidbody.AddForce(-Vector3.up * Time.deltaTime, ForceMode.Impulse);
            // Rigidbody.velocity += Vector3.up * Physics.gravity.y * (Rigidbody.velocity.y < 0 
            //     ? (FallMultiplier - 1f) 
            //     : (JumpMulitplier - 1f) * (Input.GetButton("Jump") ? 0f : 1f)) * Time.fixedDeltaTime;
        }

        public void UpdatePosition(Vector3 direction = default, float movementSpeed = default)
        {
            var finalPosition = direction * movementSpeed * Time.deltaTime;

            Move(finalPosition);
        }

        public void Move(Vector3 direction)
        {
            _rigidbody.AddForce(direction, ForceMode.VelocityChange);
        }

        private bool IsGrounded()
        {
            return true;
        }
    }
}