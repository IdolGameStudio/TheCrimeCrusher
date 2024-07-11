using _Project.StaticData.Weapon;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon
{
    public class ChooseCurrentWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _laserGun;
        [SerializeField] private GameObject _plasmaRifle;
        
        public void ChangeWeapon(WeaponID weaponID)
        {
            _laserGun.SetActive(false);
            _plasmaRifle.SetActive(false);
            switch (weaponID)
            {
                case WeaponID.LaserGun:
                    _laserGun.SetActive(true);
                    break;
                case WeaponID.PlasmaRifle:
                    _plasmaRifle.SetActive(true);
                    break;
            }
        }
    }
}