using Commons;

namespace Players
{
    public class ItemInteractionAction : IInteractionAction
    {
        private readonly Item _item;

        public ItemInteractionAction(Item item)
        {
            _item = item;
        }

        public void Execute()
        {
            ServiceLocator<PlayerInventory>.Service.Add(_item);
        }
    }
}