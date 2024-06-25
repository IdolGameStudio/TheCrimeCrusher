using _Project.Services.InputService;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerIdle: ICharacterState
    {
        private Animator _animator;
        private readonly IInputService _inputService;
        private readonly CharacterStateMachine _stateMachine;
        private readonly PlayerSM _playerSm;

        public PlayerIdle(Animator animator, IInputService inputService, CharacterStateMachine stateMachine, PlayerSM playerSm)
        {
            _animator = animator;
            _inputService = inputService;
            _stateMachine = stateMachine;
            _playerSm = playerSm;
        } 
        public void Enter()
        {
        }

        public void Execute()
        {
        }

        public void LogicUpdate()
        {
            if (_inputService.IsMoving())
            {
                _stateMachine.ChangeState(_playerSm.WalkState);
            }
        }

        public void Exit()
        {
        }
    }
}