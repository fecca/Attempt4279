using UnityEngine;

namespace Movements
{
    public interface IMovement
    {
        void Move(Vector3 direction = default, float movementSpeed = 1, float turnSpeed = 1);
        bool IsMoving();
        float GetVelocity();
    }
}