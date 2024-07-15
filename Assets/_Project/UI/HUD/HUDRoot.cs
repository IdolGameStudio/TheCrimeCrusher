using System;
using _Project.GamePlay.Player.PlayerWeapon;
using _Project.Infrastructure.Factories;
using _Project.Services.PlayerProgressService;
using _Project.Services.StaticDataService;
using _Project.StaticData.Weapon;
using _Project.UI.HUD.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _Project.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private WeaponItemController _laserPistol;
        [SerializeField] private WeaponItemController _plasmaRifle;
        [SerializeField] private WeaponItemController _electromagneticHammer;
        [SerializeField] private GameObject _fireDrone;
        private IPlayerProgressService _playerProgressService;
        private IGameFactory _gameFactory;

        private ChooseCurrentWeapon _chooseCurrentWeapon;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(IGameFactory gameFactory, IPlayerProgressService playerProgressService, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
            _chooseCurrentWeapon = _gameFactory.Player.GetComponentInChildren<ChooseCurrentWeapon>();
        }
        
        public void Initialize()
        {
            if (_playerProgressService.Progress.LaserPistolLevel > 0) AddWeaponOnHUD(WeaponID.LaserPistol);
            if (_playerProgressService.Progress.PlasmaRifleLevel > 0) AddWeaponOnHUD(WeaponID.PlasmaRifle);
            if (_playerProgressService.Progress.ElectromagneticHammerLevel > 0) AddWeaponOnHUD(WeaponID.ElectromagneticHammer);
            if (_playerProgressService.Progress.FireDroneLevel > 0) _fireDrone.SetActive(true);
        }

        private void AddWeaponOnHUD(WeaponID weaponID)
        {
            switch (weaponID)
            {
                case WeaponID.LaserPistol:
                    _laserPistol.gameObject.SetActive(true);
                    _laserPistol.SetIcon(_staticDataService.GetWeaponData(weaponID).WeaponSprite);
                    break;
                case WeaponID.PlasmaRifle:
                    _plasmaRifle.gameObject.SetActive(true);
                    _plasmaRifle.SetIcon(_staticDataService.GetWeaponData(weaponID).WeaponSprite);
                    break;
                case WeaponID.ElectromagneticHammer:
                    _electromagneticHammer.gameObject.SetActive(true);
                    _electromagneticHammer.SetIcon(_staticDataService.GetWeaponData(weaponID).WeaponSprite);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponID), weaponID, null);
            }
        }

        public void ChangeWeapon(WeaponID weaponID) => 
            _chooseCurrentWeapon.ChangeWeapon(weaponID);

        public class Factory : PlaceholderFactory<HUDRoot>
        {
            
        }
    }
}