using System;
using Items;

namespace Loot
{
    [Serializable]
    public class LootItem
    {
        public ItemBlueprint Blueprint;
        public int Amount;
        public int Weight;

        public override string ToString()
        {
            return $"{Blueprint.id}, Amount: {Amount}";
        }
    }
}