using _Project.Scripts.Infrastructure.Factories;
using UnityEngine;

namespace _Project.Scripts.GamePlay.CharacterSM.EnemyState
{
    public class EnemyDeadState: ICharacterState
    {
        private readonly IGameFactory _gameFactory;
        private readonly GameObject _myself;
        private readonly Animator _animator;
        private bool _isDead;
        private static readonly int _dead = Animator.StringToHash("Dead");
        
        private float _timeToDestroy = 3f;

        public EnemyDeadState(IGameFactory gameFactory, GameObject myself, Animator animator)
        {
            _gameFactory = gameFactory;
            _myself = myself;
            _animator = animator;
        }
        public void Enter()
        {
            _isDead = true;
            _gameFactory.Enemies.Remove(_myself);
            _animator.SetTrigger(_dead);
        }

        public void Execute()
        {
        }

        public void LogicUpdate()
        {
            if (!_isDead) return;
            _timeToDestroy -= Time.deltaTime;
            if(_timeToDestroy <= 0) 
                Exit();

        }

        public void Exit()
        {
            GameObject.Destroy(_myself);
        }
    }
}