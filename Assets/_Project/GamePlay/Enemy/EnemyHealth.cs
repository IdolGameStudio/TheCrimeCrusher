using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.GamePlay.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private EnemyDeath _enemyDeath;
        [FormerlySerializedAs("_enemyData")] [SerializeField] private EnemyDataMonoBehavior _enemyDataMonoBehavior;
        
        private float _currentHealth;
        private float _maxHealth;

        private void Start()
        {
            _maxHealth = _enemyDataMonoBehavior.MaxHealth;
            ResetHealth();
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _enemyDeath.Death();
            }
        }

        private void ResetHealth() => 
            _currentHealth = _maxHealth;
    }
}