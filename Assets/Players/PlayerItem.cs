namespace Players
{
    public class PlayerItem
    {
        private readonly ItemBlueprint _itemBlueprint;

        public PlayerItem(ItemBlueprint itemBlueprint, int amount)
        {
            _itemBlueprint = itemBlueprint;
            Amount = amount;
        }

        public string Id
            => _itemBlueprint.id;

        public int Amount { get; set; }

        public override string ToString()
        {
            return $"{Id}, Amount: {Amount}";
        }
    }
}