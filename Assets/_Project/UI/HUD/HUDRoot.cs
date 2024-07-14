using _Project.GamePlay.Player.PlayerWeapon;
using _Project.Infrastructure.Factories;
using _Project.Services.PlayerProgressService;
using _Project.StaticData.Weapon;
using UnityEngine;
using Zenject;

namespace _Project.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private GameObject _laserPistol;
        [SerializeField] private GameObject _plasmaRifle;
        [SerializeField] private GameObject _electromagneticHammer;
        [SerializeField] private GameObject _fireDrone;
        private IPlayerProgressService _playerProgressService;
        private IGameFactory _gameFactory;

        private ChooseCurrentWeapon _chooseCurrentWeapon;

        [Inject]
        private void Construct(IGameFactory gameFactory, IPlayerProgressService playerProgressService)
        {
            _gameFactory = gameFactory;
            _playerProgressService = playerProgressService;
            _chooseCurrentWeapon = _gameFactory.Player.GetComponentInChildren<ChooseCurrentWeapon>();
        }
        
        public void Initialize()
        {
            if (_playerProgressService.Progress.LaserPistolLevel > 0) _laserPistol.SetActive(true);
            if (_playerProgressService.Progress.PlasmaRifleLevel > 0) _plasmaRifle.SetActive(true);
            if (_playerProgressService.Progress.ElectromagneticHammerLevel > 0) _electromagneticHammer.SetActive(true);
            if (_playerProgressService.Progress.FireDroneLevel > 0) _fireDrone.SetActive(true);
        }

        public void ChangeWeapon(WeaponID weaponID) => 
            _chooseCurrentWeapon.ChangeWeapon(weaponID);

        public class Factory : PlaceholderFactory<HUDRoot>
        {
            
        }
    }
}