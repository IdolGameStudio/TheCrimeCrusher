using System;
using _Project.GamePlay.Player.PlayerWeapon.PistolWeapon;
using _Project.StaticData.Weapon;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon
{
    public class WeaponUpgrader : MonoBehaviour
    {
        [SerializeField] private PistolData _laserPistolData;
        [SerializeField] private PistolData _plasmaRifleData;
        [SerializeField] private PistolData _electromagneticHammerData; 

        public void Upgrade(WeaponID weaponID, int level)
        {
            switch (weaponID)
            {
                case WeaponID.LaserPistol:
                    _laserPistolData.Upgrade(level);
                    break;
                case WeaponID.PlasmaRifle:
                    _plasmaRifleData.Upgrade(level);
                    break;
                case WeaponID.ElectromagneticHammer:
                    _electromagneticHammerData.Upgrade(level);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponID), weaponID, null);
            }
        }
    }
}