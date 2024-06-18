using System.Collections.Generic;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerAbility.Drone
{
    public class EnemyGroupFinder
    {
        private List<GameObject> _enemies;

        public EnemyGroupFinder(List<GameObject> enemies)
        {
            _enemies = enemies;
        }

        public Vector3? FindBestTargetPosition(float range)
        {
            if (_enemies == null || _enemies.Count == 0)
            {
                return null;
            }

            Vector3 bestPosition = Vector3.zero;
            int maxEnemiesHit = 0;

            foreach (var enemy in _enemies)
            {
                int enemiesHit = 0;
                Vector3 enemyPosition = enemy.transform.position;

                foreach (var otherEnemy in _enemies)
                {
                    if (Vector3.Distance(enemyPosition, otherEnemy.transform.position) <= range)
                    {
                        enemiesHit++;
                    }
                }

                if (enemiesHit > maxEnemiesHit)
                {
                    maxEnemiesHit = enemiesHit;
                    bestPosition = enemyPosition;
                }
            }

            return bestPosition;
        }
    }
}