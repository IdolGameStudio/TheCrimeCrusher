using UnityEngine;

namespace _Project.Scripts.GamePlay.CharacterSM.EnemyState
{
    public class EnemyGetHitState: ICharacterState
    {
        private readonly EnemySM _enemySM;
        private readonly Animator _animator;
        private static readonly int _getHit = Animator.StringToHash("GetHit");

        public EnemyGetHitState(EnemySM enemySM, Animator animator)
        {
            _enemySM = enemySM;
            _animator = animator;
        }
        public void Enter()
        {
            _animator.SetTrigger(_getHit);
        }

        public void Execute()
        {
        }

        public void LogicUpdate()
        {
        }

        public void Exit()
        {
        }
    }
}