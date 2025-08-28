using System;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAttributes attributes;

        // public Vector3 Scale { get; set; }

        private void Awake()
        {
            ServiceLocator<PlayerController>.Service = this;
            ServiceLocator<PlayerAttributes>.Service = attributes;
            // Scale = Vector3.one;
        }

        private void Start()
        {
            new PlayerAttackSkill();
        }

        public event Action AttackStarted = () => { };
        public event Action AttackEnded = () => { };

        // private void Update()
        // {
        //     transform.localScale = Scale;
        // }

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