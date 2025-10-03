using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(menuName = "Assets/Create/Equipment Item", fileName = "Equipment Item")]
    public class EquipmentItemBlueprint : ItemBlueprint
    {
        public EquipmentItemStats stats;
        public EquipmentItemStats requirements;
    }
}