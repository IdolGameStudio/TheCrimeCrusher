using _Project.GamePlay.Player;
using _Project.Services.StaticDataService;
using _Project.StaticData.Enemy;
using _Project.StaticData.Level;
using _Project.UI.HUD;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly HUDRoot.Factory _hudFactory;
        private readonly IStaticDataService _staticDataService;
        

        private GameObject _player;

        public GameFactory(DiContainer diContainer, HUDRoot.Factory hudFactory, IStaticDataService staticDataService)
        {
            _diContainer = diContainer;
            _hudFactory = hudFactory;
            _staticDataService = staticDataService;
        }

        public GameObject Player => _player;

        public IHUDRoot CreateHUD() => _hudFactory.Create();

        public void Cleanup()
        {
            
        }

        public void CreatePlayer()
        {
            _player = _diContainer.InstantiatePrefab(_staticDataService.PlayerData.Prefab);
            _player.GetComponent<PlayerData>().Initialize(_staticDataService.PlayerData);
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
            _diContainer.InstantiatePrefab(_staticDataService.GetEnemyData(enemyType).Prefab, enemyPosition,
                Quaternion.identity, null);
        }
    }
}