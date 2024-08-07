using _Project.Scripts.Infrastructure.Factories;
using UnityEngine;

namespace _Project.Scripts.GamePlay.CharacterSM.EnemyState
{
    public class EnemyCombatIdleState: ICharacterState
    {
        private readonly EnemySM _enemySm;
        private readonly IGameFactory _gameFactory;
        
        private float rotationSpeed = 5f;

        public EnemyCombatIdleState(EnemySM enemySM, IGameFactory gameFactory)
        {
            _enemySm = enemySM;
            _gameFactory = gameFactory;
        }
        public void Enter()
        {
        }

        public void Execute()
        {
            Vector3 targetDirection = _gameFactory.Player.transform.position - _enemySm.transform.position;
            float step = rotationSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(_enemySm.transform.forward, targetDirection, step, 0.0f);
            _enemySm.transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
        }

        public void LogicUpdate()
        {
        }

        public void Exit()
        {
        }
    }
}