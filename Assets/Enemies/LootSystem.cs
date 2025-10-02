using System.Collections.Generic;
using System.Linq;
using Commons;
using Players;
using UnityEngine;

namespace Enemies
{
    public class LootSystem
    {
        public LootSystem()
        {
            ServiceLocator<LootSystem>.Service = this;
        }

        public void DropLoot(Vector3 position, List<LootItem> items)
        {
            var drops = LootRandomizer.GetItems(items, 2);
            drops.ForEach(Debug.Log);
            if (drops.All(d => string.IsNullOrEmpty(d.Id))) return;

            var go = new GameObject("Loot");
            var worldLootObject = go.AddComponent<WorldLootObject>();
            worldLootObject.Initialize(position, drops);
        }
    }
}