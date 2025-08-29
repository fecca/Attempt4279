using UnityEngine;

namespace Movements
{
    public interface IMovement
    {
        void ResetVelocityY();
        bool CanJump();
        void Jump(float jumpStrength);
        void ApplyGravity();
        void UpdatePosition(Vector3 direction = default, float movementSpeed = default);
        void Move(Vector3 position);
    }
}