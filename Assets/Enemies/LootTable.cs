using System.Collections.Generic;
using Players;

namespace Enemies
{
    public class LootTable
    {
        private readonly List<Item> _items;

        public LootTable(List<Item> items)
        {
            _items = items;
        }

        public Loot Get()
        {
            return new Loot(_items);
        }
    }
}