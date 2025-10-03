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

        private void Start()
        {
            _inputHandler.AttackActionTriggered += OnAttackTriggered;
            InitializeWeapon();
        }

        [Inject]
        public void Construct(IObjectResolver objectResolver, PlayerInputHandler inputHandler,
            PlayerInventory playerInventory)
        {
            _objectResolver = objectResolver;
            _inputHandler = inputHandler;
            _playerInventory = playerInventory;
        }

        private void InitializeWeapon()
        {
            var asset = Resources.Load(_playerInventory.GetWeapon()) as GameObject;
            _playerWeapon = _objectResolver.Instantiate(asset, rightHand.position, Quaternion.identity, rightHand)
                .GetComponent<IWeapon>();
        }

        private void OnAttackTriggered()
        {
            _playerWeapon.Attack();
        }
    }
}