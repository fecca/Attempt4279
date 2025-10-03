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
        public event Action<PlayerItem> ItemAdded = _ => { };

        public void Add(ItemInstance item)
        {
            if (string.IsNullOrEmpty(item.Blueprint.id)) return;

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

            ItemAdded(playerItem);

            Debug.Log($"Adding {playerItem.Amount} {playerItem.Blueprint.id} to the inventory");
        }

        public void Remove(ItemInstance item)
        {
            if (string.IsNullOrEmpty(item.Blueprint.id)) return;

            var existingItem = _items.FirstOrDefault(i => i.Blueprint.id == item.Blueprint.id);
            if (existingItem == null) return;

            existingItem.Amount -= item.Amount;
            if (existingItem.Amount <= 0) _items.Remove(existingItem);

            Debug.Log($"Removing {item.Amount} {item.Blueprint.id} from the inventory");
        }

        public List<PlayerItem> GetItems()
        {
            return _items;
        }

        public EquipmentItemBlueprint GetWeapon()
        {
            var weapon = _items.FirstOrDefault(i => i.Blueprint is EquipmentItemBlueprint);
            return weapon?.Blueprint as EquipmentItemBlueprint;
        }
    }
}