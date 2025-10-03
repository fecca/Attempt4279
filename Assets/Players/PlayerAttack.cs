using Items;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private IWeapon _playerWeapon;

        private void Awake()
        {
            _playerWeapon = GetComponent<PlayerWeapon>();
        }

        private void Start()
        {
            _inputHandler.AttackActionTriggered += OnAttackTriggered;
        }

        [Inject]
        public void Construct(PlayerInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private void OnAttackTriggered()
        {
            _playerWeapon.Attack();
        }
    }
}