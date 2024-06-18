using System.Collections.Generic;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerAbility.Drone
{
    public class AreaDamage
    {
        private List<GameObject> _enemies;

        public void Initialize(List<GameObject> enemies)
        {
            _enemies = enemies;
        }

        public void ApplyDamage(Vector3 position, float damage, float range)
        {
            foreach (var enemy in _enemies)
            {
                if (Vector3.Distance(position, enemy.transform.position) <= range)
                {
                    // Наносим урон врагу
                }
            }
        }
    }
}