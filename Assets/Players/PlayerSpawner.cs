using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Players
{
    public class PlayerSpawner : MonoBehaviour
    {
        public GameObject playerPrefab;

        private IObjectResolver _objectResolver;

        private void Start()
        {
            Spawn();
        }

        [Inject]
        public void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private void Spawn()
        {
            _objectResolver.Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}