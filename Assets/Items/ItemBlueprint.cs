using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Assets/Create/Item Blueprint", fileName = "Item Blueprint")]
    public class ItemBlueprint : ScriptableObject
    {
        public string id;
        public Sprite icon;

        public override string ToString()
        {
            return $"{id}";
        }
    }
}