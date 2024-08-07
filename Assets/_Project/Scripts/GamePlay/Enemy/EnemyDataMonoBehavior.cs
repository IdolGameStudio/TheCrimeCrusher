using _Project.Scripts.StaticData.Enemy;
using UnityEngine;

namespace _Project.Scripts.GamePlay.Enemy
{
    public class EnemyDataMonoBehavior : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        public float MaxHealth => _maxHealth;

        public void Initialize(EnemyData getEnemyData)
        {
            _maxHealth = getEnemyData.Health;
        }
    }
}