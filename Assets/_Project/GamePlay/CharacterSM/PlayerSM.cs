using _Project.GamePlay.CharacterSM.PlayerState;
using _Project.GamePlay.Player;
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

        private CharacterStateMachine _stateMachine = new CharacterStateMachine();
        private IInputService _inputService;
        
        private PlayerIdle _playerIdle;
        private PlayerWalkState _playerWalkState;

        public PlayerIdle Idle => _playerIdle;

        public PlayerWalkState WalkState => _playerWalkState;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _playerIdle = new PlayerIdle(_playerAnimator);
            _playerWalkState = new PlayerWalkState(_stateMachine, this, _characterController, _inputService, _playerData, _playerAnimator);
            _stateMachine.ChangeState(Idle);
        }

        private void Update()
        {
            if (_inputService.IsMoving())
            {
                _stateMachine.ChangeState(WalkState);
            }

            _stateMachine.Update();
        }
    }
}