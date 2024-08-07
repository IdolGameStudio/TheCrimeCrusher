using _Project.Scripts.GamePlay.CharacterSM;
using UnityEngine;

namespace _Project.Scripts.GamePlay.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private EnemySM _enemySM;
        [SerializeField] private EnemyDataMonoBehavior _enemyDataMonoBehavior;
        
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
                _enemySM.ChangeState(_enemySM.DeadState);
            else
                _enemySM.ChangeState(_enemySM.GetHitState);
        }

        private void ResetHealth() => 
            _currentHealth = _maxHealth;
    }
}