using _Project.GamePlay.Player;
using _Project.Services.InputService;
using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerMoving : ICharacterState
    {
        private readonly CharacterController _characterController;
        private readonly IInputService _inputService;
        private readonly PlayerData _playerData;

        public PlayerMoving(CharacterController characterController,IInputService inputService, PlayerData playerData)
        {
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
            
            _characterController.Move(direction * _playerData.Speed * Time.deltaTime);
            
            // Поворачиваем персонажа к направлению движения
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, lookRotation, _playerData.RotationSpeed * Time.deltaTime);
        }

        public void Exit()
        {
        }
    }
}