using UnityEngine;
using UnityEngine.AI;

namespace Movements
{
    public class NavMeshAgentMovement : IMovement
    {
        private readonly NavMeshAgent _agent;

        public NavMeshAgentMovement(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void ResetVelocityY()
        {
        }

        public bool CanJump()
        {
            return true;
        }

        public void Jump(float jumpStrength)
        {
        }

        public void ApplyGravity()
        {
        }

        public void UpdatePosition(Vector3 direction = default, float movementSpeed = default)
        {
            _agent.speed = movementSpeed;
            Move(direction);
        }

        public void Move(Vector3 direction)
        {
            _agent.Move(direction * Time.deltaTime * _agent.speed);
            _agent.destination = _agent.transform.position + direction;
        }
    }
}