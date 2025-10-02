using System.Collections.Generic;
using Players;

namespace Enemies
{
    public class Loot
    {
        private readonly List<ItemBlueprint> _items;

        public Loot(List<ItemBlueprint> items)
        {
            _items = items;
        }

        public List<ItemBlueprint> Items()
        {
            return _items;
        }
    }
}