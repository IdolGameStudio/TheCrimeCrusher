using _Project.GamePlay.CharacterSM;
using _Project.GamePlay.Player.PlayerWeapon.PistolWeapon;
using _Project.StaticData.Weapon;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon
{
    public class ChooseCurrentWeapon : MonoBehaviour
    {
        [SerializeField] private PlayerSM _playerSM;
        
        [SerializeField] private GameObject _laserPistol;
        [SerializeField] private GameObject _plasmaRifle;
        
        public void ChangeWeapon(WeaponID weaponID)
        {
            _laserPistol.SetActive(false);
            _plasmaRifle.SetActive(false);
            switch (weaponID)
            {
                case WeaponID.LaserPistol:
                    _laserPistol.SetActive(true);
                    _playerSM.ChangeWeaponRange(_laserPistol.GetComponent<PistolData>().Range);
                    break;
                case WeaponID.PlasmaRifle:
                    _plasmaRifle.SetActive(true);
                    _playerSM.ChangeWeaponRange(_plasmaRifle.GetComponent<PistolData>().Range);
                    break;
            }
        }
    }
}