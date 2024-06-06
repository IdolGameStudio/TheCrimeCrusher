using UnityEngine;

namespace _Project.GamePlay.Enemy
{
    public class EnemyDeath: MonoBehaviour
    {
        public void Death()
        {
            Destroy(gameObject);
        }
    }
}