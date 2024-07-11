using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "StaticData/Weapon")]
    public class WeaponStaticData: ScriptableObject
    {
        public WeaponID WeaponID;
        public Sprite WeaponSprite;
        public List<WeaponData> WeaponData;
    }
}