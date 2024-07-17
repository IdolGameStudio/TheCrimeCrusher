using _Project.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.GamePlay.Enemy
{
    public class EnemyDeath: MonoBehaviour
    {
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        } 
        public void Death()
        {
            _gameFactory.Enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}