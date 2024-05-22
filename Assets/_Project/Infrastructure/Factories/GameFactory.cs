using _Project.GamePlay.Player;
using _Project.Services.StaticDataService;
using _Project.UI.HUD;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        private readonly HUDRoot.Factory _hudFactory;
        private readonly IStaticDataService _staticDataService;
        
        private GameObject _player;
        private int _currentLevel;

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
        }

        public void CreateLevel(int level)
        {
            _currentLevel = level;
            _diContainer.InstantiatePrefab(_staticDataService.GetLevelStaticData(level).Prefab);
        }
    }
}