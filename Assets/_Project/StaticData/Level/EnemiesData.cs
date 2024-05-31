using System;
using UnityEngine;

namespace _Project.StaticData.Level
{
    [Serializable]
    public class EnemiesData
    {
        public EnemyType EnemyType;
        public Vector3 EnemyPosition;

        public EnemiesData(EnemyType enemyType, Vector3 enemyPosition)
        {
            EnemyType = enemyType;
            EnemyPosition = enemyPosition;
        }
    }
}