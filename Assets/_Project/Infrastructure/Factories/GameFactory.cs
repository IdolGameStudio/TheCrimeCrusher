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
            _player = _diContainer.InstantiatePrefab(_staticDataService.PlayerPrefab);
        }

        public void CreateLevel(int startLevelIndex)
        {
            _diContainer.InstantiatePrefab(_staticDataService.GetLevelStaticData(startLevelIndex).Prefab);
        }
    }
}