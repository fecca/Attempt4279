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

        public bool IsMoving()
        {
            return _agent.pathPending
                   || _agent.remainingDistance > _agent.stoppingDistance
                   || (_agent.hasPath && _agent.velocity.sqrMagnitude != 0f);
        }

        public void Move(Vector3 position = default, float movementSpeed = 1)
        {
            if (position == default)
            {
                _agent.destination = _agent.transform.position;
                return;
            }

            var ray = new Ray(position, Vector3.down * 10);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 0.1f);

            if (!Physics.Raycast(ray, out var hitInfo, 10.0f, LayerMask.GetMask("Ground"))) return;

            _agent.speed = movementSpeed;
            _agent.destination = hitInfo.point;
        }
    }
}