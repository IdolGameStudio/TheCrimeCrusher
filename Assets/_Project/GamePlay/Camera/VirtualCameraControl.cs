using Unity.Cinemachine;
using UnityEngine;

namespace _Project.GamePlay.Camera
{
    public class VirtualCameraControl : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _virtualCamera;

        public CinemachineCamera VirtualCamera => _virtualCamera;
    }
}