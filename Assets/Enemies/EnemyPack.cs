using UnityEngine;
using VContainer;

namespace Enemies
{
    public class EnemyPack : MonoBehaviour
    {
        private EnemySpawnPoint[] _enemySpawnPoints;
        private IObjectResolver _objectResolver;

        [Inject]
        public void Construct(IObjectResolver objectResolver)
            => _objectResolver = objectResolver;

        private void Awake()
            => _enemySpawnPoints = GetComponentsInChildren<EnemySpawnPoint>();

        private void Start()
        {
            foreach (var enemySpawnPoint in _enemySpawnPoints)
            {
                enemySpawnPoint.Spawn(_objectResolver);
            }
        }
    }
}