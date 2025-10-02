using System;

namespace Players
{
    [Serializable]
    public class LootItem
    {
        public string Id;
        public int Amount;
        public int Weight;

        public override string ToString()
        {
            return $"{Id}, Amount: {Amount}";
        }
    }
}