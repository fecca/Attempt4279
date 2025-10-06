using System;

namespace Interactions
{
    public class OpenUiAction : IInteractionAction
    {
        private readonly UI.UserInterfaceController _userInterfaceController;
        private readonly string _uiName;

        public OpenUiAction(UI.UserInterfaceController userInterfaceController, string uiName)
        {
            _uiName = uiName;
            _userInterfaceController = userInterfaceController;
        }

        public void Execute()
        {
            switch (_uiName)
            {
                case "crafting":
                    _userInterfaceController.OpenCraftingUI();
                    break;
                default:
                    throw new NotImplementedException($"Type {_uiName} not implemented");
            }
        }
    }
}