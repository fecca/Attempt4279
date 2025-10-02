using System.Collections.Generic;
using System.Linq;
using Commons;
using Players;
using UnityEngine;

namespace Loot
{
    public class LootSystem
    {
        public LootSystem()
        {
            ServiceLocator<LootSystem>.Service = this;
        }

        public void DropLoot(Vector3 position, List<LootItem> items, int lootRolls)
        {
            var drops = LootRandomizer.GetItems(items, lootRolls);
            if (drops.All(d => string.IsNullOrEmpty(d.Blueprint.id))) return;

            var go = new GameObject("Loot");
            var worldLootObject = go.AddComponent<WorldLootObject>();
            worldLootObject.Initialize(position, drops);
        }
    }
}