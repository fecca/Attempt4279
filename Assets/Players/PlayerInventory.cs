using System;
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
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
                existingItem.Amount += item.Amount;
            else
                _items.Add(new PlayerItem(item.Id, item.Amount));

            Print();
        }

        private void Print()
        {
            foreach (var item in _items) Debug.Log(item.ToString());
        }

        public string GetAsString()
        {
            return "INVENTORY"
                   + Environment.NewLine
                   + string.Join(Environment.NewLine, _items.Select(i => i.ToString()));
        }

        public int GetAmount(string itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId)?.Amount ?? 0;
        }
    }
}