using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAttributes attributes;

        private void Awake()
        {
            ServiceLocator<PlayerController>.Service = this;
            ServiceLocator<PlayerAttributes>.Service = attributes;
        }

        public event Action AttackStarted = () => { };
        public event Action AttackEnded = () => { };

        public void StartAttack()
        {
            AttackStarted.Invoke();
        }

        public void EndAttack()
        {
            AttackEnded.Invoke();
        }
    }
}