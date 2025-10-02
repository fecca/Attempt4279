namespace Players
{
    public class PlayerItem
    {
        public readonly ItemBlueprint Blueprint;

        public PlayerItem(ItemBlueprint blueprint, int amount)
        {
            Blueprint = blueprint;
            Amount = amount;
        }

        public string Id
            => Blueprint.id;

        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Id}, Amount: {Amount}";
        }
    }
}