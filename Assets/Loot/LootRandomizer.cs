using System.Collections.Generic;
using System.Linq;
using Players;
using UnityEngine;

namespace Loot
{
    public class LootRandomizer
    {
        public static List<LootItem> GetItems(List<LootItem> items, int rolls)
        {
            float totalWeight = items.Sum(item => item.Weight);
            var weightTable = new Dictionary<float, LootItem>();
            var accumulatedWeight = 0f;
            foreach (var item in items)
            {
                accumulatedWeight += item.Weight;
                var percentage = accumulatedWeight / totalWeight;
                weightTable[percentage] = item;
            }

            var rolledItems = new List<LootItem>();
            for (var i = 0; i < rolls; i++)
            {
                var random = Random.value;
                foreach (var weightedItem in weightTable)
                {
                    if (!(random <= weightedItem.Key)) continue;

                    rolledItems.Add(weightedItem.Value);
                    break;
                }
            }

            return rolledItems;
        }
    }
}