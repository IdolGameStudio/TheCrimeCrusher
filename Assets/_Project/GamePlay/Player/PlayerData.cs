using UnityEngine;

namespace _Project.GamePlay.Player
{
    public class PlayerData: MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _rotationSpeed = 2f; 

        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;
    }
}