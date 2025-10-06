using UnityEngine;

namespace Items.Scripts
{
    public abstract class ItemBlueprint : ScriptableObject
    {
        public string id;
        public Sprite icon;

        public override string ToString()
            => $"{id}";
    }
}