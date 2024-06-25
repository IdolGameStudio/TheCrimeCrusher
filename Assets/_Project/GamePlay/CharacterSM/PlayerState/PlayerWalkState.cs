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
        private readonly Animator _animator;
        private readonly CharacterStateMachine _stateMachine;
        private readonly PlayerSM _playerSm;

        private static readonly int _walk = Animator.StringToHash("Walk");
        private static readonly int _run = Animator.StringToHash("Run");
        
        private float _walkTime;

        public PlayerWalkState(Animator animator, CharacterStateMachine stateMachine, PlayerSM playerSM,
            CharacterController characterController, IInputService inputService, PlayerData playerData)
        {
            _animator = animator;
            _stateMachine = stateMachine;
            _playerSm = playerSM;
            _characterController = characterController;
            _inputService = inputService;
            _playerData = playerData;
        }

        public void Enter()
        {
            _animator.SetBool(_walk, true);
            _walkTime = 0f;
        }

        public void Execute()
        {
            Vector3 direction = _inputService.GetInputDirection();

            if (direction == Vector3.zero) return;

            _characterController.Move(direction * _playerData.WalkSpeed * Time.deltaTime);

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation,
                lookRotation, _playerData.RotationSpeed * Time.deltaTime);
        }

        public void LogicUpdate()
        {
            _walkTime += Time.deltaTime;
            if (_walkTime >= _playerData.WalkTimeBeforeRun)
            {
                _animator.SetBool(_run, true);
                _stateMachine.ChangeState(_playerSm.RunState);
            }
            if (_playerSm.CanShootEnemy())
            {
                _stateMachine.ChangeState(_playerSm.AimState);
            }

            if (!_inputService.IsMoving())
            {
                _stateMachine.ChangeState(_playerSm.Idle);
            }
        }

        public void Exit()
        {
            _animator.SetBool(_walk, false);
        }
    }
}