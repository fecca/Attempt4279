using UnityEngine;

namespace Players
{
    [CreateAssetMenu(menuName = "Assets/Create/Item Blueprint", fileName = "Item Blueprint")]
    public class ItemBlueprint : ScriptableObject
    {
        public string id;

        public override string ToString()
        {
            return $"{id}";
        }
    }
}