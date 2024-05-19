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
        
        private CharacterStateMachine _stateMachine = new CharacterStateMachine();
        private IInputService _inputService;
        private PlayerIdle _playerIdle;
        private PlayerMoving _playerMoving;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _playerIdle = new PlayerIdle();
            _playerMoving = new PlayerMoving(_characterController,_inputService, _playerData);
            _stateMachine.ChangeState(_playerIdle);
        }

        private void Update()
        {
            
            _stateMachine.Update();
            if (_inputService.IsMoving())
            {
                _stateMachine.ChangeState(_playerMoving);
            }
            else
            {
                _stateMachine.ChangeState(_playerIdle);
            }
        }
    }
}