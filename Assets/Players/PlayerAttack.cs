using Items.Scripts;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Transform rightHand;

        private PlayerInputHandler _inputHandler;
        private IWeapon _playerWeapon;

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
            _playerWeapon?.Attack();
        }
    }
}