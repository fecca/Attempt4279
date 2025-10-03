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
            if (interactionAction is ItemInteractionAction action)
            {
                action.AddDependency(_playerInventory);
                return action;
            }

            throw new NotImplementedException($"Type {interactionAction.GetType()} not implemented");
        }
    }
}