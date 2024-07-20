using _Project.GamePlay.Enemy;
using _Project.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.GamePlay.CharacterSM
{
    public class EnemySM : MonoBehaviour
    {
        [SerializeField] private EnemyDataMonoBehavior _enemyData;
        [SerializeField] private Animator _enemyAnimator;
        
        private CharacterStateMachine _stateMachine;
        
        private EnemyIdleState _enemyIdleState;
        private EnemyRunState _enemyRunState;
        private EnemyDeadState _enemyDeadState;
        private EnemyAttackState _enemyAttackState;
        private EnemyCombatIdleState _enemyCombatIdleState;
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        private void Awake()
        {
            _stateMachine = new CharacterStateMachine();
            _enemyIdleState = new EnemyIdleState();
            _enemyRunState = new EnemyRunState();
            _enemyDeadState = new EnemyDeadState();
            _enemyAttackState = new EnemyAttackState();
            _enemyCombatIdleState = new EnemyCombatIdleState();
            _stateMachine.ChangeState(_enemyIdleState);
        }
        
        private void Update()
        {
            _stateMachine.Update();
            _stateMachine.LogicUpdate();
        }
        
        public void ChangeState(ICharacterState state)
        {
            _stateMachine.ChangeState(state);
        }
    }
}