using System.Collections.Generic;
using System.Linq;
using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerInventory
    {
        private readonly List<PlayerItem> _items = new();

        public PlayerInventory()
        {
            ServiceLocator<PlayerInventory>.Service = this;
        }

        public void Add(ItemInstance itemInstance)
        {
            if (string.IsNullOrEmpty(itemInstance.Blueprint.id)) return;

            var existingItem = _items.FirstOrDefault(i => i.Id == itemInstance.Blueprint.id);
            if (existingItem != null)
                existingItem.Amount += itemInstance.Amount;
            else
                _items.Add(new PlayerItem(itemInstance.Blueprint, itemInstance.Amount));

            Debug.Log($"Adding {itemInstance.Amount} {itemInstance.Blueprint.id} to the inventory");
        }

        public PlayerItem GetAmount(string itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }
    }
}