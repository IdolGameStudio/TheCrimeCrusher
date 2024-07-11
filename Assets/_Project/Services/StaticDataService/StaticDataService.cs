﻿using System.Collections.Generic;
using System.Linq;
using _Project.StaticData.Enemy;
using _Project.StaticData.Level;
using _Project.StaticData.Player;
using _Project.StaticData.Weapon;
using UnityEngine;

namespace _Project.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string PlayerPath = "StaticData/Player/PlayerStaticData";
        private const string LevelsPath = "StaticData/Levels";
        private const string WeaponsPath = "StaticData/Weapons";
        private const string EnemyPath = "StaticData/Enemy/EnemyStaticData";

        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WeaponID, WeaponStaticData> _weapons;
        private Dictionary<EnemyType, EnemyData> _enemies;
        private PlayerStaticData _playerStaticData;

        public PlayerStaticData PlayerData => _playerStaticData;

        public void Initialize()
        {
            // load your configs here
            Debug.Log("Static data loaded");

            _playerStaticData = Resources.Load<PlayerStaticData>(PlayerPath);
            _enemies = Resources.Load<EnemyStaticData>(EnemyPath).Enemies.ToDictionary(x => x.EnemyType, x => x);
            _levels = Resources.LoadAll<LevelStaticData>(LevelsPath).ToDictionary(x => x.LevelName, x => x);
            _weapons = Resources.LoadAll<WeaponStaticData>(WeaponsPath).ToDictionary(x => x.WeaponID, x => x);
        }


        public LevelStaticData GetLevelStaticData(string levelName) =>
            _levels.TryGetValue(levelName, out LevelStaticData levelData)
                ? levelData
                : null;

        public EnemyData GetEnemyData(EnemyType enemyType) =>
            _enemies.TryGetValue(enemyType, out EnemyData enemyData)
                ? enemyData
                : null;
        
        public WeaponStaticData GetWeaponData(WeaponID weaponID) =>
            _weapons.TryGetValue(weaponID, out WeaponStaticData weaponData)
                ? weaponData
                : null;
    }
}