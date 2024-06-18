using _Project.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.GamePlay.Player.PlayerWeapon
{
    public class FindNearbyTarget: MonoBehaviour
    {
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public GameObject FindTarget()
        {
            if(_gameFactory.Enemies.Count == 0) return null;
            GameObject target = _gameFactory.Enemies[0];
            foreach (var enemy in _gameFactory.Enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, target.transform.position))
                {
                    target = enemy;
                }
            }
            return target; 
        }
    }
}