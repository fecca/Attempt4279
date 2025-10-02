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

        public void Add(Item item)
        {
            if (string.IsNullOrEmpty(item.Id)) return;

            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
                existingItem.Amount += item.Amount;
            else
                _items.Add(new PlayerItem(item.Id, item.Amount));

            Debug.Log($"Adding item: {item}");
        }

        public int GetAmount(string itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId)?.Amount ?? 0;
        }
    }
}