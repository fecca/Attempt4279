using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Enemies
{
    public class EnemyPackSpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyPack enemyPrefab;

        public void Spawn(IObjectResolver objectResolver)
            => objectResolver.Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
    }
}