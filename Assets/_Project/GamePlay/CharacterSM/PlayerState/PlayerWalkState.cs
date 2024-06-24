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

        public PlayerWalkState(CharacterStateMachine stateMachine, PlayerSM playerSM, CharacterController characterController, IInputService inputService, PlayerData playerData)
        {
            _stateMachine = stateMachine;
            _playerSm = playerSM;
            _characterController = characterController;
            _inputService = inputService;
            _playerData = playerData;
        }

        public void Enter()
        {
        }

        public void Execute()
        {
            Vector3 direction = _inputService.GetInputDirection();
            if (!_inputService.IsMoving())
            {
                _stateMachine.ChangeState(_playerSm.StopState);
                return;
            }
            if (direction == Vector3.zero) return;

            if (_playerSm.CanShootEnemy())
            {
                _stateMachine.ChangeState(_playerSm.AimState);
                return;
            }

            _characterController.Move(direction * _playerData.WalkSpeed * Time.deltaTime);
        
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, lookRotation, _playerData.RotationSpeed * Time.deltaTime);
        }

        public void Exit()
        {
        }
    }
}