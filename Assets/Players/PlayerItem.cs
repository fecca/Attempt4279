namespace Players
{
    public class PlayerItem
    {
        public PlayerItem(string id, int amount)
        {
            Id = id;
            Amount = amount;
        }

        public string Id { get; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Id}, Amount: {Amount}";
        }
    }
}