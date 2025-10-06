using System;
using Inputs;
using Players;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class UserInterfaceController : MonoBehaviour
    {
        public event Action UiOpened = () => { };
        public event Action UiClosed = () => { };

        [SerializeField] private GameObject panel;

        [SerializeField] private CraftingInterface craftingInterface;

        [SerializeField] private GameObject equipmentPanel;
        [SerializeField] private Image weaponImage;

        [SerializeField] private GameObject itemsPanel;
        [SerializeField] private Image itemsTab;
        [SerializeField] private InventoryItem itemPrefab;

        private GameObject _activeTab;
        private bool _isInitialized;
        private PlayerInputHandler _playerInputHandler;
        private PlayerInventory _playerInventory;
        private UIInputHandler _uiInputHandler;
        private IObjectResolver _objectResolver;

        [Inject]
        public void Construct(PlayerInventory playerInventory, PlayerInputHandler playerInputHandler,
            UIInputHandler uiInputHandler, IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
            _uiInputHandler = uiInputHandler;
            _playerInputHandler = playerInputHandler;
            _playerInventory = playerInventory;

            craftingInterface.Initialize(_playerInventory, _objectResolver, _uiInputHandler);
        }

        private void OnEnable()
        {
            _playerInputHandler.OpenMenuActionTriggered += OnOpenMenuActionTriggered;
            _uiInputHandler.BackMenuActionTriggered += OnBackMenuActionTriggered;
        }

        private void OnDisable()
        {
            _playerInputHandler.OpenMenuActionTriggered -= OnOpenMenuActionTriggered;
            _uiInputHandler.BackMenuActionTriggered -= OnBackMenuActionTriggered;
        }

        public void OpenCraftingUI()
        {
            craftingInterface.Show();

            UiOpened.Invoke();
        }

        private void OnOpenMenuActionTriggered()
        {
            panel.SetActive(true);

            PopulateEquipmentItems();
            PopulateInventoryItems();

            UiOpened.Invoke();
        }

        private void PopulateEquipmentItems()
        {
            var weapon = _playerInventory.GetWeapon();
            if (weapon == null) return;

            weaponImage.sprite = weapon.icon;

            UiClosed.Invoke();
        }

        private void PopulateInventoryItems()
        {
            foreach (var inventoryItem in itemsPanel.GetComponentsInChildren<InventoryItem>())
                Destroy(inventoryItem.gameObject);

            _playerInventory.GetItems().ForEach(item =>
            {
                var inventoryItem = Instantiate(itemPrefab, itemsPanel.transform);
                inventoryItem.Initialize(item);
            });
        }

        private void OnBackMenuActionTriggered()
        {
            panel.SetActive(false);
            craftingInterface.Hide();

            UiClosed.Invoke();
        }
    }
}