using System;
using UnityEngine;

namespace Players
{
    public class PlayerObserver
    {
        public event Action<Transform> PlayerSpawned = _ => { };

        public void NotifyPlayerSpawned(Transform playerTransform)
            => PlayerSpawned(playerTransform);
    }
}