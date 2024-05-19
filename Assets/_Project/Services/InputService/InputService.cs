using UnityEngine;

namespace _Project.Services.InputService
{
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 inputDirection;

        public Vector3 GetInputDirection()
        {
            inputDirection.x = Input.GetAxis(Horizontal);
            inputDirection.z = Input.GetAxis(Vertical);
            inputDirection.y = 0f;

            return inputDirection.normalized;
        }
    }
}