using System.Collections.Generic;
using Items.Scripts;
using Players;

namespace Interactions
{
    public class AddItemToInventoryAction : IInteractionAction
    {
        private readonly List<ItemInstance> _items;
        private readonly PlayerInventory _playerInventory;

        public AddItemToInventoryAction(PlayerInventory playerInventory, List<ItemInstance> items)
        {
            _playerInventory = playerInventory;
            _items = items;
        }

        public void Execute()
            => _items.ForEach(item => _playerInventory.Add(item));
    }
}