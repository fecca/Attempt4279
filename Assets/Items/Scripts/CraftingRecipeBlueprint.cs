using System.Collections.Generic;
using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(menuName = "Assets/Create/Crafting Recipe", fileName = "Crafting Recipe")]
    public class CraftingRecipeBlueprint : ItemBlueprint
    {
        public ItemBlueprint result;
        public List<CraftingRecipeRequirement> requirements;
    }
}