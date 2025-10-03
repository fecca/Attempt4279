using Items.Scripts;

namespace Players
{
    public abstract class Weapon : EquipmentItem, IWeapon
    {
        public abstract void Attack();
    }
}