using UnityEngine;

namespace Players
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerAttributes")]
    public class PlayerAttributes : ScriptableObject
    {
        public float movementSpeed = 10.0f;
        public float jumpStrength = 2.0f;
        public float attackSpeed = 5.0f;
    }
}