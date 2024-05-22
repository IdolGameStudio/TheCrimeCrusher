using System.Collections.Generic;
using System.Linq;
using _Project.StaticData.Level;
using _Project.StaticData.Player;
using UnityEngine;

namespace _Project.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string PlayerPath = "StaticData/Player/PlayerStaticData";
        private const string LevelsPath = "StaticData/Levels/Level";

        private Dictionary<int, LevelData> _levels;
        private PlayerStaticData _playerStaticData;

        public PlayerStaticData PlayerData => _playerStaticData;

        public void Initialize()
        {
            // load your configs here
            Debug.Log("Static data loaded");

            _playerStaticData = Resources.Load<PlayerStaticData>(PlayerPath);

            _levels = Resources.Load<LevelStaticData>(LevelsPath).LevelsData
                .ToDictionary(x => x.LevelIndex, x => x);
        }

        public LevelData GetLevelStaticData(int levelIndex) =>
            _levels.TryGetValue(levelIndex, out LevelData levelData)
                ? levelData
                : null;
    }
}