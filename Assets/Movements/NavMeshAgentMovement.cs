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

        public void Move(Vector3 direction = default, float movementSpeed = default)
        {
            if (direction == default)
            {
                _agent.destination = _agent.transform.position;
                return;
            }

            // ToDo: raycast from up+5 causes attempted movement to higher ground by sliding and walking around
            var ray = new Ray(_agent.transform.position + Vector3.up * 5.0f + direction, Vector3.down * 10);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 0.1f);

            if (!Physics.Raycast(ray, out var hitInfo, 10.0f, LayerMask.GetMask("Ground"))) return;

            _agent.speed = movementSpeed;
            _agent.destination = hitInfo.point;
        }
    }
}