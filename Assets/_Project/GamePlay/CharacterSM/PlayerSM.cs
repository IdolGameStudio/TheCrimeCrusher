using _Project.GamePlay.CharacterSM.PlayerState;
using _Project.GamePlay.Player;
using _Project.Infrastructure.Factories;
using _Project.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Project.GamePlay.CharacterSM
{
    public class PlayerSM : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private WeaponData _currentWeapon; // Текущее оружие игрока

        private CharacterStateMachine _stateMachine = new CharacterStateMachine();
        private IInputService _inputService;
    
        private PlayerIdle _playerIdle;
        private PlayerWalkState _playerWalkState;
        private PlayerRunState _playerRunState;
        private PlayerStopState _playerStopState;
        private PlayerAimState _playerAimState;
        private EnemyDetector _enemyDetector;

        private float _walkTime;
        private IGameFactory _gameFactory;

        public PlayerIdle Idle => _playerIdle;
        public PlayerWalkState WalkState => _playerWalkState;
        public PlayerRunState RunState => _playerRunState;
        public PlayerStopState StopState => _playerStopState;
        public PlayerAimState AimState => _playerAimState;


        [Inject]
        private void Construct(IInputService inputService, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _inputService = inputService;
        }

        private void Start()
        {
            var enemies = _gameFactory.Enemies;
            _enemyDetector = new EnemyDetector(enemies);

            _playerIdle = new PlayerIdle(_playerAnimator);
            _playerWalkState = new PlayerWalkState(_stateMachine, this, _characterController, _inputService, _playerData, _playerAnimator);
            _playerRunState = new PlayerRunState(_stateMachine, this, _characterController, _inputService, _playerData, _playerAnimator);
            _playerStopState = new PlayerStopState(_stateMachine, this, _characterController, _playerData, _playerAnimator, _inputService);
            _playerAimState = new PlayerAimState(_stateMachine, this, _characterController, _playerData, _playerAnimator, _inputService, _gameFactory);
            _stateMachine.ChangeState(Idle);
        }

        private void Update()
        {
            if (_inputService.IsMoving())
            {
                _walkTime += Time.deltaTime;
                if (_walkTime >= _playerData.WalkTimeBeforeRun)
                {
                    _stateMachine.ChangeState(RunState);
                }
                else
                {
                    _stateMachine.ChangeState(WalkState);
                }
            }
            else
            {
                _walkTime = 0;
                _stateMachine.ChangeState(StopState);
            }

            _stateMachine.Update();
        }

        public bool CanShootEnemy()
        {
            return _enemyDetector.IsEnemyInRange(transform.position, _currentWeapon.range);
        }
    }

    public class WeaponData
    {
        public float range;
    }
}