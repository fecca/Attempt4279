using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
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