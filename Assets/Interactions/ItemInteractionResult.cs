using System.Collections.Generic;
using Items.Scripts;

namespace Interactions
{
    public class ItemInteractionResult : IInteractionResult
    {
        private readonly List<ItemInstance> _itemInstances;

        public ItemInteractionResult(ItemInstance itemInstance)
        {
            _itemInstances = new List<ItemInstance> { itemInstance };
        }

        public ItemInteractionResult(List<ItemInstance> itemInstances)
        {
            _itemInstances = itemInstances;
        }
        
        public List<ItemInstance> GetResult()
        {
            return _itemInstances;
        }
    }
}