using _Project.Scripts.GamePlay.Player;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Services.InputService;
using UnityEngine;

namespace _Project.Scripts.GamePlay.CharacterSM.PlayerState
{
    public class PlayerAimState : ICharacterState
    {
    private readonly CharacterController _characterController;
    private readonly PlayerData _playerData;
    private readonly CharacterStateMachine _stateMachine;
    private readonly PlayerSM _playerSm;
    private readonly IInputService _inputService;
    private readonly IGameFactory _gameFactory;
    private readonly Animator _animator;
    
    private static readonly int _aim = Animator.StringToHash("Aim");
    private static readonly int _horizontal = Animator.StringToHash("Horizontal");
    private static readonly int _vertical = Animator.StringToHash("Vertical");

    private GameObject _currentTarget;
    private float _checkInterval = 0.5f; // Интервал проверки состояния противника
    private float _nextCheckTime;

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
        if (_currentTarget != FindClosestEnemy()) _currentTarget = FindClosestEnemy();
        if (_currentTarget == null) return;
      
        Vector3 directionToTarget = (_currentTarget.transform.position - _characterController.transform.position)
            .normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation,
            lookRotation, _playerData.RotationSpeed * Time.deltaTime);

        Vector3 inputDirection = _inputService.GetInputDirection();
        if (inputDirection == Vector3.zero)
        {
            _animator.SetFloat(_horizontal, 0);
            _animator.SetFloat(_vertical, 0);
            return;
        }

        Vector3 relativeDirection = _characterController.transform.InverseTransformDirection(inputDirection);
        HandleMovementAnimation(relativeDirection);

        _characterController.Move(inputDirection * _playerData.RunSpeed * Time.deltaTime);
    }

    public void LogicUpdate()
    {
        if (_currentTarget == null || !_playerSm.CanShootEnemy())
        {
            _stateMachine.ChangeState(_playerSm.RunState);
        }
        
        if (Time.time >= _nextCheckTime)
        {
            _nextCheckTime = Time.time + _checkInterval;
            if (_currentTarget == null) 
            {
                _currentTarget = FindClosestEnemy();
                if (_currentTarget == null)
                {
                    _stateMachine.ChangeState(_playerSm.RunState);
                }
            }
        }
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
        _animator.SetFloat(_horizontal, relativeDirection.x);
        _animator.SetFloat(_vertical, relativeDirection.z);
    }
}
}