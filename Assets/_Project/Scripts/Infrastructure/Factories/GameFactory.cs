using System.Collections.Generic;
using _Project.Scripts.GamePlay.Enemy;
using _Project.Scripts.GamePlay.Player;
using _Project.Scripts.GamePlay.Player.PlayerWeapon;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.StaticData.Enemy;
using _Project.Scripts.StaticData.Level;
using _Project.Scripts.StaticData.Weapon;
using _Project.Scripts.UI.HUD;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly HUDRoot.Factory _hudFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerProgressService _playerProgressService;

        private List<GameObject> _enemies = new List<GameObject>();

        private GameObject _player;
        
        private HUDRoot _hudRoot;

        public GameFactory(DiContainer diContainer, HUDRoot.Factory hudFactory, IStaticDataService staticDataService, IPlayerProgressService playerProgressService)
        {
            _diContainer = diContainer;
            _hudFactory = hudFactory;
            _staticDataService = staticDataService;
            _playerProgressService = playerProgressService;
        }

        public GameObject Player => _player;

        public List<GameObject> Enemies => _enemies;

        public IHUDRoot CreateHUD()
        {
            _hudRoot = _hudFactory.Create();
            _hudRoot.Initialize();
            return _hudRoot;
        }

        public void Cleanup()
        {
        }

        public void CreatePlayer()
        {
            _player = _diContainer.InstantiatePrefab(_staticDataService.PlayerData.Prefab);
            _player.GetComponent<PlayerData>().Initialize(_staticDataService.PlayerData);
            SetWeaponLevel();
            SetPlayerPositionInLevel();
            _player.GetComponentInChildren<ChooseCurrentWeapon>().ChangeWeapon(WeaponID.LaserPistol);
        }

        private void SetWeaponLevel()
        {
            if(_playerProgressService.Progress.LaserPistolLevel > 0)
                _player.GetComponent<WeaponUpgrader>().Upgrade(WeaponID.LaserPistol, _playerProgressService.Progress.LaserPistolLevel-1);

            if(_playerProgressService.Progress.PlasmaRifleLevel > 0)
                _player.GetComponent<WeaponUpgrader>().Upgrade(WeaponID.PlasmaRifle, _playerProgressService.Progress.PlasmaRifleLevel-1);

            // if(_playerProgressService.Progress.ElectromagneticHammerLevel > 0)
            //     _player.GetComponent<WeaponUpgrader>().Upgrade(WeaponID.ElectromagneticHammer, _playerProgressService.Progress.ElectromagneticHammerLevel);
            //
            // if(_playerProgressService.Progress.FireDroneLevel > 0)
            //     _player.GetComponent<WeaponUpgrader>().Upgrade(WeaponID.FireDrone, _playerProgressService.Progress.FireDroneLevel);
        }

        private void SetPlayerPositionInLevel()
        {
            _player.SetActive(false);
            string levelName = SceneManager.GetActiveScene().name;
            _player.transform.position = _staticDataService.GetLevelStaticData(levelName).PlayerPosition;
            _player.SetActive(true);
        }

        public void CreateEnemyInLevel()
        {
            string levelName = SceneManager.GetActiveScene().name;
            LevelStaticData levelStaticData = _staticDataService.GetLevelStaticData(levelName);
            foreach (EnemiesLevelData enemy in levelStaticData.Enemies)
            {
                CreateEnemy(enemy.EnemyType, enemy.EnemyPosition);
            }
        }

        private void CreateEnemy(EnemyType enemyType, Vector3 enemyPosition)
        {
            var enemy = _diContainer.InstantiatePrefab(_staticDataService.GetEnemyData(enemyType).Prefab, enemyPosition,
                Quaternion.identity, null);

            enemy.GetComponent<EnemyDataMonoBehavior>().Initialize(_staticDataService.GetEnemyData(enemyType));
            _enemies.Add(enemy);
        }
    }
}