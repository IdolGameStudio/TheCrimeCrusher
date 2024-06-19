using System.Collections.Generic;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM
{
    public class EnemyDetector
    {
        private List<GameObject> _enemies;

        public EnemyDetector(List<GameObject> enemies)
        {
            _enemies = enemies;
        }

        public bool IsEnemyInRange(Vector3 position, float range)
        {
            foreach (var enemy in _enemies)
            {
                if (Vector3.Distance(position, enemy.transform.position) <= range)
                {
                    return true;
                }
            }
            return false;
        }
    }
}