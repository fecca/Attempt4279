using Items.Scripts;
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
        private const int PatrolRadius = 10;
        private const int LootRolls = 2;

        [SerializeField] private LootTable lootTable;

        private LootSystem _lootSystem;
        private IMovement _movement;
        private PlayerObserver _playerObserver;
        private Transform _targetPlayer;

        private void Awake()
        {
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
            if (other.gameObject.GetComponentInParent<IWeapon>() != null) TakeDamage();
        }

        [Inject]
        public void Construct(LootSystem lootSystem, PlayerObserver playerObserver)
        {
            _playerObserver = playerObserver;
            _lootSystem = lootSystem;

            _playerObserver.PlayerSpawned += OnPlayerSpawned;
        }

        private void OnPlayerSpawned(Transform targetPlayer)
        {
            _targetPlayer = targetPlayer;
        }

        private Vector3 PickNewRandomPosition()
        {
            var randomPosition = Random.insideUnitCircle * PatrolRadius;
            return transform.position + new Vector3(randomPosition.x, transform.position.y, randomPosition.y);
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

        [ContextMenu("kill")]
        public void Kill()
        {
            TakeDamage();
        }
    }
}