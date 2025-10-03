using System;
using Players;

namespace Interactions
{
    public class InteractionActionFactory
    {
        private readonly PlayerInventory _playerInventory;

        public InteractionActionFactory(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        public IInteractionAction Create(IInteractionAction interactionAction)
        {
            if (interactionAction == null) return new EmptyInteractionAction();

            if (interactionAction is ItemInteractionAction itemInteractionAction)
            {
                itemInteractionAction.AddDependency(_playerInventory);
                return itemInteractionAction;
            }

            if (interactionAction is CraftingInteractionAction craftingInteractionAction)
            {
                craftingInteractionAction.AddDependency(_playerInventory);
                return craftingInteractionAction;
            }

            throw new NotImplementedException($"Type {interactionAction.GetType()} not implemented");
        }
    }
}