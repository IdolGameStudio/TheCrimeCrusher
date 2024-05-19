using UnityEngine;

namespace _Project.Services.InputService
{
    public class MobileInputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 inputDirection;

        public Vector3 GetInputDirection()
        {
            inputDirection.x = SimpleInput.GetAxis(Horizontal);
            inputDirection.z = SimpleInput.GetAxis(Vertical);
            inputDirection.y = 0f;

            return inputDirection.normalized;
        }
    }
}