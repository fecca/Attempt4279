using System.Collections.Generic;
using System.Linq;
using Inputs;
using Items.Scripts;
using Players;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class CraftingInterface : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup craftingGrid;
        [SerializeField] private CraftingRecipeItem craftingItemPrefab;

        private readonly List<CraftingRecipeItem> _recipeItems = new();

        private PlayerInventory _playerInventory;
        private IObjectResolver _objectResolver;
        private UIInputHandler _uiInputHandler;
        private int _selectedIndex;
        private List<PlayerCraftingRecipe> _craftingRecipes;

        public void Initialize(PlayerInventory playerInventory, IObjectResolver objectResolver,
            UIInputHandler uiInputHandler)
        {
            _uiInputHandler = uiInputHandler;
            _objectResolver = objectResolver;
            _playerInventory = playerInventory;
        }

        public void Show()
        {
            _uiInputHandler.UpArrowActionTriggered += OnUpArrowActionTriggered;
            _uiInputHandler.DownArrowActionTriggered += OnDownArrowActionTriggered;
            _uiInputHandler.SubmitActionTriggered += OnSubmitActionTriggered;

            CreateItems();

            gameObject.SetActive(true);
        }

        private void CreateItems()
        {
            _craftingRecipes = _playerInventory.GetRecipes();
            if (!_craftingRecipes.Any()) return;

            foreach (var craftingRecipe in _craftingRecipes)
            {
                var recipeItem = _objectResolver.Instantiate(craftingItemPrefab, craftingGrid.transform);
                recipeItem.Initialize(_objectResolver, craftingRecipe.Blueprint.result.id,
                    craftingRecipe.Blueprint.requirements, _playerInventory);

                _recipeItems.Add(recipeItem);
            }

            SelectItem(_selectedIndex);
        }

        private void OnSubmitActionTriggered()
        {
            // Craft
            var canCraft = _playerInventory.HasResources(_craftingRecipes[_selectedIndex].Blueprint.requirements);
            if (!canCraft) return;
            var itemsToBeRemoved = _craftingRecipes[_selectedIndex].Blueprint.requirements
                .Select(r => new ItemInstance(r.resource, r.amount)).ToList();
            var itemToAdd = new ItemInstance(_craftingRecipes[_selectedIndex].Blueprint.result, 1);
            _playerInventory.Remove(itemsToBeRemoved);
            _playerInventory.Add(itemToAdd);

            DestroyItems();
            CreateItems();
        }

        private void SelectItem(int index)
        {
            _recipeItems[_selectedIndex].UnHighLight();
            _selectedIndex = index;
            _recipeItems[_selectedIndex].HighLight();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _uiInputHandler.UpArrowActionTriggered -= OnUpArrowActionTriggered;
            _uiInputHandler.DownArrowActionTriggered -= OnDownArrowActionTriggered;
            DestroyItems();
        }

        private void DestroyItems()
        {
            foreach (var recipeItem in _recipeItems)
            {
                Destroy(recipeItem.gameObject);
            }

            _recipeItems.Clear();
        }

        private void OnUpArrowActionTriggered()
        {
            if (_selectedIndex == 0) return;
            SelectItem(_selectedIndex - 1);
        }

        private void OnDownArrowActionTriggered()
        {
            if (_selectedIndex == _recipeItems.Count - 1) return;
            SelectItem(_selectedIndex + 1);
        }
    }
}