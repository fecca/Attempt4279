using Interactions;

namespace Players
{
    public class CraftingBenchInteractionAction : IInteractionAction
    {
        private UI.UserInterfaceController _userInterfaceController;

        public void Execute()
        {
            _userInterfaceController.OpenCraftingUI();
        }

        public void AddDependency(UI.UserInterfaceController userInterfaceController)
        {
            _userInterfaceController = userInterfaceController;
        }
    }
}