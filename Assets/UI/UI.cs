using Commons;
using Inputs;
using Players;
using UnityEngine;
using UnityEngine.UI;

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

        private void Update()
        {
            if (!_isInitialized) Initialize();
        }

        private void OnDisable()
        {
            ServiceLocator<PlayerInputHandler>.Service.OpenMenuActionTriggered -= OnOpenMenuActionTriggered;
            ServiceLocator<UIInputHandler>.Service.CloseMenuActionTriggered -= OnCloseMenuActionTriggered;
            ServiceLocator<UIInputHandler>.Service.PageLeftActionTriggered -= OnPageLeftActionTriggered;
            ServiceLocator<UIInputHandler>.Service.PageRightActionTriggered -= OnPageRightActionTriggered;
        }

        private void Initialize()
        {
            ServiceLocator<PlayerInputHandler>.Service.OpenMenuActionTriggered += OnOpenMenuActionTriggered;
            ServiceLocator<UIInputHandler>.Service.CloseMenuActionTriggered += OnCloseMenuActionTriggered;
            ServiceLocator<UIInputHandler>.Service.PageLeftActionTriggered += OnPageLeftActionTriggered;
            ServiceLocator<UIInputHandler>.Service.PageRightActionTriggered += OnPageRightActionTriggered;

            _isInitialized = true;
        }

        private void OnOpenMenuActionTriggered()
        {
            panel.SetActive(true);

            foreach (var inventoryItem in itemsPanel.GetComponentsInChildren<InventoryItem>())
                Destroy(inventoryItem.gameObject);

            ServiceLocator<PlayerInventory>.Service.GetItems().ForEach(item =>
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