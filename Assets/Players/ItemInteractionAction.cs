using System.Collections.Generic;
using Commons;

namespace Players
{
    public class ItemInteractionAction : IInteractionAction
    {
        private readonly List<ItemInstance> _items;

        public ItemInteractionAction(List<ItemInstance> items)
        {
            _items = items;
        }

        public void Execute()
        {
            _items.ForEach(item => ServiceLocator<PlayerInventory>.Service.Add(item));
        }
    }
}