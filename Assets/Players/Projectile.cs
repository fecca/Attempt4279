using UnityEngine;

namespace Players
{
    public class Projectile : MonoBehaviour
    {
        private const float Lifetime = 2.0f;

        private float _attackSped;

        private void Start()
        {
            transform.localScale = Vector3.one * 0.2f;

            Destroy(gameObject, Lifetime);
        }

        private void Update()
        {
            transform.position += transform.forward * Time.deltaTime * _attackSped;
        }

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }

        public void Initialize(Vector3 spawnPosition, Vector3 forward, float attackSped)
        {
            _attackSped = attackSped;
            transform.position = spawnPosition + forward;
            transform.forward = forward;
        }
    }
}