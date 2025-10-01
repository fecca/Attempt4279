using System.Collections.Generic;
using Players;

namespace Enemies
{
    public class Loot
    {
        private readonly List<Item> _items;

        public Loot(List<Item> items)
        {
            _items = items;
        }

        public List<Item> Items()
        {
            return _items;
        }
    }
}