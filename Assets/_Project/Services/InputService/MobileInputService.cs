using UnityEngine;

namespace _Project.Services.InputService
{
    public class MobileInputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 _inputDirection;

        public Vector3 GetInputDirection()
        {
            _inputDirection.x = SimpleInput.GetAxis(Horizontal);
            _inputDirection.z = SimpleInput.GetAxis(Vertical);
            _inputDirection.y = 0f;
Debug.Log(IsMoving());
            return _inputDirection.normalized;
        }

        public bool IsMoving() => Input.GetAxis(Horizontal) != 0 || Input.GetAxis(Vertical) != 0;
        
    }
}