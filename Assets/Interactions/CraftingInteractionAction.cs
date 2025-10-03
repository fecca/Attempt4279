using System.Collections.Generic;
using Items.Scripts;
using Players;

namespace Interactions
{
    public class CraftingInteractionAction : IInteractionAction
    {
        private readonly List<ItemInstance> _cost;
        private readonly ItemInstance _newItem;
        private PlayerInventory _playerInventory;

        public CraftingInteractionAction(ItemInstance newItem, List<ItemInstance> cost)
        {
            _cost = cost;
            _newItem = newItem;
        }

        public void Execute()
        {
            _playerInventory.Add(_newItem);
            _cost.ForEach(item => _playerInventory.Remove(item));
        }

        public void AddDependency(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }
    }
}