using UnityEngine;

namespace _Project.Scripts.Services.InputService
{
    public interface IInputService
    {
        Vector3 GetInputDirection();
        bool IsMoving();
    }
}