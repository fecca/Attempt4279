using System.Collections.Generic;
using Items.Scripts;
using Players;

namespace Interactions
{
    public class ItemInteractionAction : IInteractionAction
    {
        private readonly List<ItemInstance> _items;

        private PlayerInventory _playerInventory;

        public ItemInteractionAction(List<ItemInstance> items)
        {
            _items = items;
        }

        public void Execute()
        {
            _items.ForEach(item => _playerInventory.Add(item));
        }

        public void AddDependency(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }
    }
}