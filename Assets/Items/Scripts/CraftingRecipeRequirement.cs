using System;

namespace Items.Scripts
{
    [Serializable]
    public class CraftingRecipeRequirement
    {
        public ItemBlueprint resource;
        public int amount;
    }
}