using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Players
{
    public class PlayerSpawner : MonoBehaviour
    {
        public GameObject playerPrefab;

        private IObjectResolver _objectResolver;
        private PlayerObserver _playerObserver;

        [Inject]
        public void Construct(IObjectResolver objectResolver, PlayerObserver playerObserver)
        {
            _playerObserver = playerObserver;
            _objectResolver = objectResolver;
        }

        private void Start()
            => Spawn();

        private void Spawn()
        {
            var player = _objectResolver.Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
            _playerObserver.NotifyPlayerSpawned(player.transform);
        }
    }
}