using System;

namespace _Project.StaticData.Weapon
{
    [Serializable]
    public class WeaponData
    {
        public float Range;
        public float Damage;
        public float TimeBetweenShots;
        public float ReloadTime;
        public int BulletsCount;
        public float BulletSpeed;
        
    }
}