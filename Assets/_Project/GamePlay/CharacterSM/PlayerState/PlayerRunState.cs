using _Project.GamePlay.Player;
using _Project.Services.InputService;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerRunState : ICharacterState
    {
        private readonly CharacterController _characterController;
        private readonly IInputService _inputService;
        private readonly PlayerData _playerData;
        private readonly CharacterStateMachine _stateMachine;
        private readonly PlayerSM _playerSm;
        private readonly Animator _animator;
        
        private static readonly int _run = Animator.StringToHash("Run");

        public PlayerRunState(CharacterStateMachine stateMachine, PlayerSM playerSM, CharacterController characterController, IInputService inputService, PlayerData playerData, Animator animator)
        {
            _stateMachine = stateMachine;
            _playerSm = playerSM;
            _animator = animator;
            _characterController = characterController;
            _inputService = inputService;
            _playerData = playerData;
        }

        public void Enter()
        {
            _animator.SetBool(_run, true);
        }

        public void Execute()
        {
            Vector3 direction = _inputService.GetInputDirection();
            
            if (direction == Vector3.zero) return;

            _characterController.Move(direction * _playerData.RunSpeed * Time.deltaTime);
        
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, lookRotation, _playerData.RotationSpeed * Time.deltaTime);
        }

        public void LogicUpdate()
        {
            if (!_inputService.IsMoving())
            {
                _stateMachine.ChangeState(_playerSm.Idle);
            }
            if (_playerSm.CanShootEnemy())
            {
                _stateMachine.ChangeState(_playerSm.AimState);
            }
        }

        public void Exit()
        {
            _animator.SetBool(_run, false);
        }
    }
}