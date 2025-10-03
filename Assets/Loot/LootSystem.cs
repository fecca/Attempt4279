using System.Collections.Generic;
using System.Linq;
using Commons;
using Interactions;
using Players;
using UnityEngine;

namespace Loot
{
    public class LootSystem
    {
        private InteractionActionFactory _interactionActionFactory;

        public LootSystem(InteractionActionFactory interactionActionFactory)
        {
            _interactionActionFactory = interactionActionFactory;
        }
        
        public void DropLoot(Vector3 position, List<LootItem> items, int lootRolls)
        {
            var drops = LootRandomizer.GetItems(items, lootRolls);
            if (drops.All(d => string.IsNullOrEmpty(d.Blueprint.id))) return;

            var go = new GameObject("Loot");
            var worldLootObject = go.AddComponent<WorldLootObject>();
            worldLootObject.Initialize(_interactionActionFactory, position, drops);
        }
    }
}