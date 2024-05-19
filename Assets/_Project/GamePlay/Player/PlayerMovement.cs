using _Project.Services.InputService;
using UnityEngine;
using Zenject;

namespace _Project.GamePlay.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerData _playerData;
        
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        private void Update()
        {
            Vector3 moveDirection = _inputService.GetInputDirection();

            _characterController.Move(moveDirection * (_playerData.Speed * Time.deltaTime));
        }
    }
}