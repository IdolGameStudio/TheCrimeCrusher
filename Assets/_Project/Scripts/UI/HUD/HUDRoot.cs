using System;
using _Project.Scripts.GamePlay.Player.PlayerWeapon;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.StaticData.Special;
using _Project.Scripts.StaticData.Weapon;
using _Project.Scripts.UI.HUD.Special;
using _Project.Scripts.UI.HUD.Weapons;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private WeaponItemController _laserPistol;
        [SerializeField] private WeaponItemController _plasmaRifle;
        [SerializeField] private WeaponItemController _electromagneticHammer;
        [SerializeField] private SpecialItemController _fireDrone;
        [SerializeField] private SpecialItemController _energyShield;
        [SerializeField] private SpecialItemController _fieryExplosion;
        [SerializeField] private SpecialItemController _healing;
        
        
        [SerializeField] private CurrentWeapon _currentWeapon;
        
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
            if (_playerProgressService.Progress.LaserPistolLevel > 0) AddWeaponToHUD(WeaponID.LaserPistol);
            if (_playerProgressService.Progress.PlasmaRifleLevel > 0) AddWeaponToHUD(WeaponID.PlasmaRifle);
            if (_playerProgressService.Progress.ElectromagneticHammerLevel > 0) AddWeaponToHUD(WeaponID.ElectromagneticHammer);
            if (_playerProgressService.Progress.FireDroneLevel > 0) AddSpecialToHUD(SpecialID.FireDrone);
            if (_playerProgressService.Progress.EnergyShieldLevel > 0) AddSpecialToHUD(SpecialID.EnergyShield);
            if (_playerProgressService.Progress.FieryExplosionLevel > 0) AddSpecialToHUD(SpecialID.FieryExplosion);
            if (_playerProgressService.Progress.HealingLevel > 0) AddSpecialToHUD(SpecialID.Healing);
            ChangeWeapon(WeaponID.LaserPistol);
        }

        private void AddSpecialToHUD(SpecialID fireDrone)
        {
            switch (fireDrone)
            {
                case SpecialID.FireDrone:
                    _fireDrone.gameObject.SetActive(true);
                    _fireDrone.SetIcon(_staticDataService.GetSpecialData(fireDrone).SpecialIcon);
                    break;
                case SpecialID.EnergyShield:
                    _energyShield.gameObject.SetActive(true);
                    _energyShield.SetIcon(_staticDataService.GetSpecialData(fireDrone).SpecialIcon);
                    break;
                case SpecialID.FieryExplosion:
                    _fieryExplosion.gameObject.SetActive(true);
                    _fieryExplosion.SetIcon(_staticDataService.GetSpecialData(fireDrone).SpecialIcon);
                    break;
                case SpecialID.Healing:
                    _healing.gameObject.SetActive(true);
                    _healing.SetIcon(_staticDataService.GetSpecialData(fireDrone).SpecialIcon);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fireDrone), fireDrone, null);
            }
        }

        private void AddWeaponToHUD(WeaponID weaponID)
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

        public void ChangeWeapon(WeaponID weaponID)
        {
            _chooseCurrentWeapon.ChangeWeapon(weaponID);
            _currentWeapon.SetIcon(_staticDataService.GetWeaponData(weaponID).WeaponSprite);
        }

        public class Factory : PlaceholderFactory<HUDRoot>
        {
            
        }

        public void UseSpecial(SpecialID id)
        {
        }
    }
}