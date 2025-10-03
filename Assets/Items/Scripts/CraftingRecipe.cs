using System;
using System.Collections.Generic;
using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(menuName = "Assets/Create/Crafting Recipe", fileName = "Crafting Recipe")]
    public class CraftingRecipe : ScriptableObject
    {
        public ItemBlueprint result;
        public List<CraftingRequirement> requirements;
    }

    [Serializable]
    public class CraftingRequirement
    {
        public ResourceItemBlueprint resource;
        public int amount;
    }
}