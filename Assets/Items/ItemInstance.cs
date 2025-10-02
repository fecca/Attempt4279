namespace Items
{
    public class ItemInstance
    {
        public ItemInstance(ItemBlueprint blueprint, int amount)
        {
            Amount = amount;
            Blueprint = blueprint;
        }

        public ItemBlueprint Blueprint { get; }

        public int Amount { get; }
    }
}