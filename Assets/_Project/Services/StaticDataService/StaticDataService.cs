using System.Collections.Generic;
using System.Linq;
using _Project.StaticData;
using UnityEngine;

namespace _Project.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string PlayerPath = "StaticData/Player/PlayerPrefab";
        private const string LevelsPath = "StaticData/Levels/LevelStaticData";

        private Dictionary<int, LevelData> _levels;

        private GameObject _playerPrefab;

        public GameObject PlayerPrefab => _playerPrefab;

        public void Initialize()
        {
            // load your configs here
            Debug.Log("Static data loaded");

            _playerPrefab = Resources.Load<GameObject>(PlayerPath);
            if(_playerPrefab == null) Debug.Log("Player prefab not found");

            _levels = Resources.Load<LevelStaticData>(LevelsPath).LevelsData
                .ToDictionary(x => x.LevelIndex, x => x);
        }

        public LevelData GetLevelStaticData(int levelIndex) =>
            _levels.TryGetValue(levelIndex, out LevelData levelData)
                ? levelData
                : null;
    }
}