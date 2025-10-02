namespace Players
{
    public static class LootItemExtensions
    {
        public static Item AsItem(this LootItem lootItem)
        {
            return new Item(lootItem.Id, lootItem.Amount);
        }
    }
}