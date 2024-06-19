using _Project.StaticData.Player;
using UnityEngine;

namespace _Project.GamePlay.Player
{
    public class PlayerData: MonoBehaviour
    {
        [SerializeField] private float _walkSpeed = 2f;
        [SerializeField] private float _runSpeed = 6f; 
        [SerializeField] private float _rotationSpeed = 2f; 
        [SerializeField] private float _walkTimeBeforeRun = 1.5f; 
        [SerializeField] private float _stopTime = 1f; 
        

        public float WalkSpeed => _walkSpeed;
        public float RotationSpeed => _rotationSpeed;
        public float RunSpeed => _runSpeed;
        public float WalkTimeBeforeRun => _walkTimeBeforeRun;

        public float StopTime => _stopTime;

        public void Initialize(PlayerStaticData playerData)
        {
            _walkSpeed = playerData.WalkSpeed;
            _rotationSpeed = playerData.RotateSpeed;
        }
    }
}