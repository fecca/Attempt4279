using Inputs;
using Players;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject itemsPanel;
        [SerializeField] private GameObject craftingPanel;
        [SerializeField] private Image itemsTab;
        [SerializeField] private Image craftingTab;
        [SerializeField] private InventoryItem itemPrefab;

        private GameObject _activeTab;
        private bool _isInitialized;
        private PlayerInputHandler _playerInputHandler;
        private PlayerInventory _playerInventory;
        private UIInputHandler _uiInputHandler;

        private void OnEnable()
        {
            _playerInputHandler.OpenMenuActionTriggered += OnOpenMenuActionTriggered;
            _uiInputHandler.CloseMenuActionTriggered += OnCloseMenuActionTriggered;
            _uiInputHandler.PageLeftActionTriggered += OnPageLeftActionTriggered;
            _uiInputHandler.PageRightActionTriggered += OnPageRightActionTriggered;
        }

        private void OnDisable()
        {
            _playerInputHandler.OpenMenuActionTriggered -= OnOpenMenuActionTriggered;
            _uiInputHandler.CloseMenuActionTriggered -= OnCloseMenuActionTriggered;
            _uiInputHandler.PageLeftActionTriggered -= OnPageLeftActionTriggered;
            _uiInputHandler.PageRightActionTriggered -= OnPageRightActionTriggered;
        }

        [Inject]
        public void Construct(PlayerInventory playerInventory, PlayerInputHandler playerInputHandler,
            UIInputHandler uiInputHandler)
        {
            _uiInputHandler = uiInputHandler;
            _playerInputHandler = playerInputHandler;
            _playerInventory = playerInventory;
        }

        private void OnOpenMenuActionTriggered()
        {
            panel.SetActive(true);

            foreach (var inventoryItem in itemsPanel.GetComponentsInChildren<InventoryItem>())
                Destroy(inventoryItem.gameObject);

            _playerInventory.GetItems().ForEach(item =>
            {
                var inventoryItem = Instantiate(itemPrefab, itemsPanel.transform);
                inventoryItem.Initialize(item);
            });
        }

        private void OnCloseMenuActionTriggered()
        {
            panel.SetActive(false);
        }

        private void OnPageLeftActionTriggered()
        {
            itemsTab.color = new Color(0f, 0f, 1f, 0.75f);
            craftingTab.color = new Color(0f, 0f, 0f, 0.75f);
            itemsPanel.SetActive(true);
            craftingPanel.SetActive(false);
        }

        private void OnPageRightActionTriggered()
        {
            itemsTab.color = new Color(0f, 0f, 0f, 0.75f);
            craftingTab.color = new Color(0f, 0f, 1f, 0.75f);
            itemsPanel.SetActive(false);
            craftingPanel.SetActive(true);
        }
    }
}