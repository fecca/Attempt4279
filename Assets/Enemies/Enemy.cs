using Loot;
using Movements;
using Players;
using UnityEngine;
using UnityEngine.AI;
using VContainer;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        private const int MaxHealth = 3;
        private const int PatrolRadius = 3;
        private const int LootRolls = 2;

        [SerializeField] private LootTable lootTable;

        private int _currentHealth;
        private bool _isBeingAttacked;
        private LootSystem _lootSystem;
        private IMovement _movement;

        private void Awake()
        {
            _currentHealth = MaxHealth;
            _movement = new NavMeshAgentMovement(GetComponent<NavMeshAgent>());
        }

        private void Update()
        {
            if (_movement.IsMoving()) return;

            var position = PickNewRandomPosition();
            _movement.Move(position);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Projectile>()) TakeDamage();
        }

        [Inject]
        public void Construct(LootSystem lootSystem)
        {
            _lootSystem = lootSystem;
        }

        private Vector3 PickNewRandomPosition()
        {
            var randomPosition = Random.insideUnitCircle * PatrolRadius;
            return transform.position + new Vector3(randomPosition.x, transform.position.y, randomPosition.y);
        }

        public void OnAttacked()
        {
            if (_isBeingAttacked) return;

            _isBeingAttacked = true;
            EndAttacked();
        }

        private void EndAttacked()
        {
            _isBeingAttacked = false;
            _currentHealth--;
            if (_currentHealth <= 0) Destroy(gameObject);
        }

        private void TakeDamage()
        {
            DropLoot();
            Destroy(gameObject);
        }

        private void DropLoot()
        {
            _lootSystem.DropLoot(transform.position, lootTable.items, LootRolls);
        }
    }
}