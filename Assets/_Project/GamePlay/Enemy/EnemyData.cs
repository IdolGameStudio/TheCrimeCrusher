using UnityEngine;

namespace _Project.GamePlay.Enemy
{
    public class EnemyData : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        public float MaxHealth => _maxHealth; 
    }
}