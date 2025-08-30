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
            return false;
        }

        public void Jump(float jumpStrength)
        {
        }

        public void ApplyGravity()
        {
        }

        public void UpdatePosition(Vector3 direction = default, float movementSpeed = default)
        {
            if (direction == default)
            {
                _agent.destination = _agent.transform.position;
                return;
            }

            var ray = new Ray(_agent.transform.position + Vector3.up * 5.0f + direction, Vector3.down * 10);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 0.1f);

            if (!Physics.Raycast(ray, out var hitInfo, 10.0f, LayerMask.GetMask("Ground"))) return;

            _agent.speed = movementSpeed;
            _agent.destination = hitInfo.point;
        }
    }
}