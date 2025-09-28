namespace Players
{
    public class Item
    {
        public Item(string id, int amount)
        {
            Id = id;
            Amount = amount;
        }

        public string Id { get; }
        public int Amount { get; }
    }
}