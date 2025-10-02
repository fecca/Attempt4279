using UnityEngine;
using VContainer;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPackSpawnPoint[] _enemyPackSpawnPoints;
        private IObjectResolver _objectResolver;

        private void Awake()
        {
            _enemyPackSpawnPoints = GetComponentsInChildren<EnemyPackSpawnPoint>();
        }

        private void Start()
        {
            foreach (var enemyPackSpawnPoint in _enemyPackSpawnPoints) enemyPackSpawnPoint.Spawn(_objectResolver);
        }

        [Inject]
        public void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
    }
}