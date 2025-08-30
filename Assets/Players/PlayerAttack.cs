using Commons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private InputActionReference attackAction;

        private void Start()
        {
            ServiceLocator<InputHandler>.Service.AttackActionTriggered += OnAttackTriggered;
        }

        private static void OnAttackTriggered()
        {
            ServiceLocator<PlayerController>.Service.StartAttack();
        }
    }
}