using System;
using Commons;
using Interactables;
using UnityEngine;

namespace Players
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAttributes attributes;

        private void Awake()
        {
            ServiceLocator<PlayerController>.Service = this;
            ServiceLocator<PlayerAttributes>.Service = attributes;
        }

        private void Start()
        {
            // new PlayerAttackSkill(this);
            new PlayerInventory();
            new InputActionMapController();
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