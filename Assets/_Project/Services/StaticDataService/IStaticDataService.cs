﻿using _Project.StaticData.Enemy;
using _Project.StaticData.Level;
using _Project.StaticData.Player;

namespace _Project.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        PlayerStaticData PlayerData { get; }
        LevelStaticData GetLevelStaticData(int levelIndex);
        EnemyData GetEnemyData(EnemyType enemyType);
    }
}