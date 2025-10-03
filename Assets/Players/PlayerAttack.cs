using Items;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        private IWeapon _playerWeapon;
        private PlayerInputHandler _inputHandler;

        [Inject]
        public void Construct(PlayerInputHandler inputHandler)
            => _inputHandler = inputHandler;

        private void Awake()
            => _playerWeapon = GetComponent<PlayerWeapon>();

        private void Start()
            => _inputHandler.AttackActionTriggered += OnAttackTriggered;

        private void OnAttackTriggered()
            => _playerWeapon.Attack();
    }
}