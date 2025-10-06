using System;
using Players;

namespace Interactions
{
    public class InteractionActionFactory
    {
        private readonly PlayerInventory _playerInventory;
        private readonly UI.UserInterfaceController _userInterfaceController;

        public InteractionActionFactory(PlayerInventory playerInventory, UI.UserInterfaceController userInterfaceController)
        {
            _userInterfaceController = userInterfaceController;
            _playerInventory = playerInventory;
        }

        public IInteractionAction Create(IInteractionResult result)
        {
            switch (result)
            {
                case ItemInteractionResult itemInteractionResult:
                    return new AddItemToInventoryAction(_playerInventory, itemInteractionResult.GetResult());
                case UIInteractionResult uiInteractionResult:
                    return new OpenUiAction(_userInterfaceController, uiInteractionResult.GetResult());
                case null:
                    return new EmptyInteractionAction();
                default:
                    throw new NotImplementedException($"Type {result.GetType()} not implemented");
            }
        }
    }
}