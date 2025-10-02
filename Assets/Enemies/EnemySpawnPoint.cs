using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Enemies
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;

        public void Spawn(IObjectResolver objectResolver)
        {
            objectResolver.Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}