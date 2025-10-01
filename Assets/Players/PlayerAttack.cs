using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        private IWeapon _playerWeapon;

        private void Awake()
        {
            _playerWeapon = GetComponent<PlayerWeapon>();
        }

        private void Start()
        {
            ServiceLocator<PlayerInputHandler>.Service.AttackActionTriggered += OnAttackTriggered;
        }

        private void OnAttackTriggered()
        {
            _playerWeapon.Attack();
        }
    }
}