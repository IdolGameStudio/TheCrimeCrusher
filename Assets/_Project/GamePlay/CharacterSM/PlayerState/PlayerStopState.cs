using _Project.GamePlay.Player;
using _Project.Services.InputService;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerStopState : ICharacterState
    {
        private readonly CharacterController _characterController;
        private readonly PlayerData _playerData;
        private readonly CharacterStateMachine _stateMachine;
        private readonly PlayerSM _playerSm;
        private readonly IInputService _inputService;
        private Animator _animator;
        private static readonly int _stop = Animator.StringToHash("Stop");

        private float _stopTimer;
        private Vector3 _initialVelocity;

        public PlayerStopState(CharacterStateMachine stateMachine, PlayerSM playerSM, CharacterController characterController, PlayerData playerData, Animator animator, IInputService inputService)
        {
            _stateMachine = stateMachine;
            _playerSm = playerSM;
            _animator = animator;
            _characterController = characterController;
            _playerData = playerData;
            _inputService = inputService;
        }

        public void Enter()
        {
            _animator.SetBool(_stop, true);
            _stopTimer = 0f;
            _initialVelocity = _characterController.velocity;
        }

        public void Execute()
        {
            if (_inputService.IsMoving())
            {
                _stateMachine.ChangeState(_playerSm.WalkState);
                return;
            }

            _stopTimer += Time.deltaTime;
            float t = _stopTimer / _playerData.StopTime;
            Vector3 newVelocity = Vector3.Lerp(_initialVelocity, Vector3.zero, t);
            _characterController.Move(newVelocity * Time.deltaTime);

            if (_stopTimer >= _playerData.StopTime)
            {
                _stateMachine.ChangeState(_playerSm.Idle);
            }
        }

        public void Exit()
        {
            _animator.SetBool(_stop, false);
        }
    }
}