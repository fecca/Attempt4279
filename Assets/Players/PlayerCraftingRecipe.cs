using Items.Scripts;

namespace Players
{
    public class PlayerCraftingRecipe
    {
        public readonly CraftingRecipeBlueprint Blueprint;

        public PlayerCraftingRecipe(CraftingRecipeBlueprint blueprint)
            => Blueprint = blueprint;
    }
}