using _Project.StaticData.Player;
using UnityEngine;

namespace _Project.GamePlay.Player
{
    public class PlayerData: MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _rotationSpeed = 2f; 

        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;

        public void Initialize(PlayerStaticData playerData)
        {
            _speed = playerData.MoveSpeed;
            _rotationSpeed = playerData.RotateSpeed;
        }
    }
}