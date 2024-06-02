using System;
using _Project.StaticData.Enemy;
using UnityEngine;

namespace _Project.StaticData.Level
{
    [Serializable]
    public class EnemiesLevelData
    {
        public EnemyType EnemyType;
        public Vector3 EnemyPosition;

        public EnemiesLevelData(EnemyType enemyType, Vector3 enemyPosition)
        {
            EnemyType = enemyType;
            EnemyPosition = enemyPosition;
        }
    }
}