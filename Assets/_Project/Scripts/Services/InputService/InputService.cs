using UnityEngine;

namespace _Project.Scripts.Services.InputService
{
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 _inputDirection;

        public Vector3 GetInputDirection()
        {
            _inputDirection = Vector3.zero;
            _inputDirection.x = SimpleInput.GetAxis(Horizontal);
            _inputDirection.z = SimpleInput.GetAxis(Vertical);
            _inputDirection.y = 0f;

            return _inputDirection.normalized;
        }
        
        public bool IsMoving() => _inputDirection.sqrMagnitude > 0.01f;
    }
}