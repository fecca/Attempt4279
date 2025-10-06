using Items.Scripts;

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

        public int Amount { get; set; }

        public override string ToString()
            => $"{Blueprint.id}, Amount: {Amount}";
    }
}