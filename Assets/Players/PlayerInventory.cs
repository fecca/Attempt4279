using System;
using System.Collections.Generic;
using System.Linq;
using Items.Scripts;
using UnityEngine;

namespace Players
{
    public class PlayerInventory
    {
        private readonly List<PlayerItem> _items = new();
        private readonly List<PlayerCraftingRecipe> _craftingRecipes = new();
        public event Action<PlayerItem> ItemAdded = _ => { };

        public void Add(ItemInstance item)
        {
            if (string.IsNullOrEmpty(item.Blueprint.id)) return;

            switch (item.Blueprint)
            {
                case EquipmentItemBlueprint or ResourceItemBlueprint:
                {
                    var playerItem = _items.FirstOrDefault(i => i.Blueprint.id == item.Blueprint.id);
                    if (playerItem != null)
                    {
                        playerItem.Amount += item.Amount;
                    }
                    else
                    {
                        playerItem = new PlayerItem(item.Blueprint, item.Amount);
                        _items.Add(playerItem);
                    }

                    Debug.Log($"Adding {playerItem.Amount} {playerItem.Blueprint.id} to the inventory");

                    break;
                }
                case CraftingRecipeBlueprint blueprint:
                    if (_craftingRecipes.Any(i => i.Blueprint.id == item.Blueprint.id)) return;
                    var playerRecipe = new PlayerCraftingRecipe(blueprint);
                    _craftingRecipes.Add(playerRecipe);
                    break;
            }
        }

        private void Remove(ItemInstance item)
        {
            if (string.IsNullOrEmpty(item.Blueprint.id)) return;

            var existingItem = _items.FirstOrDefault(i => i.Blueprint.id == item.Blueprint.id);
            if (existingItem == null) return;

            existingItem.Amount -= item.Amount;
            if (existingItem.Amount <= 0) _items.Remove(existingItem);

            Debug.Log($"Removing {item.Amount} {item.Blueprint.id} from the inventory");
        }

        public void Remove(List<ItemInstance> items)
            => items.ForEach(Remove);

        public List<PlayerItem> GetItems()
            => _items;

        public List<PlayerCraftingRecipe> GetRecipes()
            => _craftingRecipes;

        public EquipmentItemBlueprint GetWeapon()
        {
            var weapon = _items.FirstOrDefault(i => i.Blueprint is EquipmentItemBlueprint);
            return weapon?.Blueprint as EquipmentItemBlueprint;
        }

        public bool HasResources(List<CraftingRecipeRequirement> blueprintRequirements)
        {
            foreach (var recipeRequirement in blueprintRequirements)
            {
                var existingAmount =
                    _items.FirstOrDefault(i => i.Blueprint.id == recipeRequirement.resource.id)?.Amount ?? 0;
                if (recipeRequirement.amount > existingAmount)
                {
                    return false;
                }
            }

            return true;
        }
    }
}