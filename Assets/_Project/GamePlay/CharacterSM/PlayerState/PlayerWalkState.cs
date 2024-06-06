using _Project.GamePlay.Player;
using _Project.Services.InputService;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerWalkState : ICharacterState
    {
        private readonly CharacterController _characterController;
        private readonly IInputService _inputService;
        private readonly PlayerData _playerData;
        private readonly CharacterStateMachine _stateMachine;
        private readonly PlayerSM _playerSm;
        private Animator _animator;
        private static readonly int _walk = Animator.StringToHash("Walk");

        public PlayerWalkState(CharacterStateMachine stateMachine, PlayerSM playerSM, CharacterController characterController,IInputService inputService, PlayerData playerData, Animator animator)
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
            _animator.SetBool(_walk, true);
        }

        public void Execute()
        {
            Vector3 direction = _inputService.GetInputDirection();
            if (_inputService.IsMoving() == false)
            {
                _stateMachine.ChangeState(_playerSm.Idle);
                return;
            }
            if(direction == Vector3.zero) return;
            
            _characterController.Move(direction * _playerData.WalkSpeed * Time.deltaTime);
            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, lookRotation, _playerData.RotationSpeed * Time.deltaTime);
            
        }

        public void Exit()
        {
            _animator.SetBool(_walk, false);
        }
    }
}