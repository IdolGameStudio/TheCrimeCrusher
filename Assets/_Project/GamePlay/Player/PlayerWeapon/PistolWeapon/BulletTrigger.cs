using _Project.GamePlay.Enemy;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon.PistolWeapon
{
    public class BulletTrigger : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(_bullet.Damage);
            }
            
            _bullet.ReturnToPool();
        }
    }
}