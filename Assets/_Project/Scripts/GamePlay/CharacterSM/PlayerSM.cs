using _Project.Scripts.GamePlay.CharacterSM.PlayerState;
using _Project.Scripts.GamePlay.Player;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Services.InputService;
using _Project.Scripts.StaticData.Weapon;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GamePlay.CharacterSM
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
        private PlayerAimState _playerAimState;
        private EnemyDetector _enemyDetector;

        private IGameFactory _gameFactory;

        public PlayerIdle Idle => _playerIdle;
        public PlayerWalkState WalkState => _playerWalkState;
        public PlayerRunState RunState => _playerRunState;
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

            _playerIdle = new PlayerIdle(_playerAnimator, _inputService, _stateMachine, this);
            _playerWalkState = new PlayerWalkState(_playerAnimator, _stateMachine, this, _characterController,
                _inputService, _playerData);
            _playerRunState = new PlayerRunState(_stateMachine, this, _characterController, _inputService, _playerData,
                _playerAnimator);
            _playerAimState = new PlayerAimState(_stateMachine, this, _characterController, _playerData,
                _playerAnimator, _inputService, _gameFactory);
            _stateMachine.ChangeState(Idle);
        }

        private void Update()
        {
            _stateMachine.Update();
            _stateMachine.LogicUpdate();
        }

        public void ChangeWeaponRange(float range)
        {
            _currentWeapon.Range = range;
        }

        public bool CanShootEnemy()
        {
            return _enemyDetector.IsEnemyInRange(transform.position, _currentWeapon.Range);
        }
    }
}