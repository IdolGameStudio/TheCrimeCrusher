using System;
using _Project.Scripts.StaticData.Enemy;
using UnityEngine;

namespace _Project.Scripts.StaticData.Level
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