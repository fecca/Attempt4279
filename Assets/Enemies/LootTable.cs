using System.Collections.Generic;
using Players;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(menuName = "Assets/Create/LootTable", fileName = "Loot Table")]
    public class LootTable : ScriptableObject
    {
        public List<LootItem> items;
    }
}