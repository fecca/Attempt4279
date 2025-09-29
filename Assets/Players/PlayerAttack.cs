using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        private void Start()
        {
            ServiceLocator<PlayerInputHandler>.Service.AttackActionTriggered += OnAttackTriggered;
        }

        private static void OnAttackTriggered()
        {
            ServiceLocator<PlayerController>.Service.StartAttack();
        }
    }
}