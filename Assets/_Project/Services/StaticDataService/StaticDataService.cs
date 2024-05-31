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
        private const string LevelsPath = "StaticData/Levels";

        private Dictionary<int, LevelStaticData> _levels;
        private PlayerStaticData _playerStaticData;

        public PlayerStaticData PlayerData => _playerStaticData;

        public void Initialize()
        {
            // load your configs here
            Debug.Log("Static data loaded");

            _playerStaticData = Resources.Load<PlayerStaticData>(PlayerPath);

            _levels = Resources.LoadAll<LevelStaticData>(LevelsPath).ToDictionary(x => x.LevelIndex, x => x);
        }

        public LevelStaticData GetLevelStaticData(int levelIndex) =>
            _levels.TryGetValue(levelIndex, out LevelStaticData levelData)
                ? levelData
                : null;
    }
}