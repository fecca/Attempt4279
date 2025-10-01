using Commons;
using UnityEngine;

namespace Enemies
{
    public class LootSystem
    {
        public LootSystem()
        {
            ServiceLocator<LootSystem>.Service = this;
        }

        public void DropLoot(Vector3 position, Loot loot)
        {
            var go = new GameObject("Loot");
            var worldLootObject = go.AddComponent<WorldLootObject>();
            worldLootObject.Initialize(position, loot.Items());
        }
    }
}