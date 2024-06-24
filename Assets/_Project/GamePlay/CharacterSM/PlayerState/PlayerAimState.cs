using _Project.GamePlay.Player;
using _Project.Infrastructure.Factories;
using _Project.Services.InputService;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerAimState : ICharacterState
    {
        private readonly CharacterController _characterController;
        private readonly PlayerData _playerData;
        private readonly CharacterStateMachine _stateMachine;
        private readonly PlayerSM _playerSm;
        private readonly IInputService _inputService;
        private Animator _animator;
        private GameObject _currentTarget;
        private static readonly int _aim = Animator.StringToHash("Aim");
        private static readonly int _strafeLeft = Animator.StringToHash("StrafeLeft");
        private static readonly int _strafeRight = Animator.StringToHash("StrafeRight");
        private static readonly int _moveForward = Animator.StringToHash("MoveForward");
        private static readonly int _moveBackward = Animator.StringToHash("MoveBackward");
        private float _checkInterval = 0.5f; // Интервал проверки состояния противника
        private float _nextCheckTime;
        private IGameFactory _gameFactory;

        public PlayerAimState(CharacterStateMachine stateMachine, PlayerSM playerSM,
            CharacterController characterController, PlayerData playerData, Animator animator,
            IInputService inputService, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _stateMachine = stateMachine;
            _playerSm = playerSM;
            _animator = animator;
            _characterController = characterController;
            _playerData = playerData;
            _inputService = inputService;
        }

        public void Enter()
        {
            _animator.SetBool(_aim, true);
            _currentTarget = FindClosestEnemy();
            _nextCheckTime = Time.time + _checkInterval;
        }

        public void Execute()
        {
            if (_currentTarget == null || !_playerSm.CanShootEnemy())
            {
                _stateMachine.ChangeState(_playerSm.WalkState);
                return;
            }

            // Проверка состояния противника
            if (Time.time >= _nextCheckTime)
            {
                _nextCheckTime = Time.time + _checkInterval;
                if (!_currentTarget
                        .activeInHierarchy) // Предполагается, что неактивный объект означает, что противник умер
                {
                    _currentTarget = FindClosestEnemy();
                    if (_currentTarget == null)
                    {
                        _stateMachine.ChangeState(_playerSm.WalkState);
                        return;
                    }
                }
            }

            Vector3 directionToTarget = (_currentTarget.transform.position - _characterController.transform.position)
                .normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation,
                lookRotation, _playerData.RotationSpeed * Time.deltaTime);

            Vector3 inputDirection = _inputService.GetInputDirection();
            if (inputDirection == Vector3.zero) return;

            Vector3 relativeDirection = _characterController.transform.InverseTransformDirection(inputDirection);
            HandleMovementAnimation(relativeDirection);

            _characterController.Move(inputDirection * _playerData.WalkSpeed * Time.deltaTime);
        }

        public void Exit()
        {
            _animator.SetBool(_aim, false);
        }

        private GameObject FindClosestEnemy()
        {
            var enemies = _gameFactory.Enemies;
            GameObject closestEnemy = null;
            float closestDistance = float.MaxValue;

            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(_characterController.transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        private void HandleMovementAnimation(Vector3 relativeDirection)
        {
            if (relativeDirection.z > 0)
            {
                _animator.SetBool(_moveForward, true);
                _animator.SetBool(_moveBackward, false);
            }
            else
            {
                _animator.SetBool(_moveForward, false);
                _animator.SetBool(_moveBackward, true);
            }

            if (relativeDirection.x > 0)
            {
                _animator.SetBool(_strafeRight, true);
                _animator.SetBool(_strafeLeft, false);
            }
            else
            {
                _animator.SetBool(_strafeRight, false);
                _animator.SetBool(_strafeLeft, true);
            }
        }
    }
}