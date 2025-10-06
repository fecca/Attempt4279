using Items.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Players
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Transform rightHand;

        private PlayerInputHandler _inputHandler;
        private IObjectResolver _objectResolver;
        private PlayerInventory _playerInventory;
        private IWeapon _playerWeapon;

        [Inject]
        public void Construct(IObjectResolver objectResolver, PlayerInputHandler inputHandler,
            PlayerInventory playerInventory)
        {
            _objectResolver = objectResolver;
            _inputHandler = inputHandler;
            _playerInventory = playerInventory;
        }

        private void Start()
        {
            _inputHandler.AttackActionTriggered += OnAttackTriggered;
            _playerInventory.ItemAdded += OnItemAdded;
        }

        private void OnAttackTriggered()
            => _playerWeapon?.Attack();

        private void OnItemAdded(PlayerItem item)
        {
            if (_playerWeapon != null) return;
            var weapon = _playerInventory.GetWeapon();
            if (weapon == null) return;

            var asset = Resources.Load(weapon.id) as GameObject;
            _playerWeapon = _objectResolver.Instantiate(asset, rightHand.position, Quaternion.identity, rightHand)
                .GetComponent<IWeapon>();
        }
    }
}