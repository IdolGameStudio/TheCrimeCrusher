using _Project.StaticData.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.GamePlay.Player
{
    public class PlayerData: MonoBehaviour
    {
        [FormerlySerializedAs("_speed")] [SerializeField] private float _walkSpeed = 2f;
        [SerializeField] private float _rotationSpeed = 2f; 

        public float WalkSpeed => _walkSpeed;
        public float RotationSpeed => _rotationSpeed;

        public void Initialize(PlayerStaticData playerData)
        {
            _walkSpeed = playerData.WalkSpeed;
            _rotationSpeed = playerData.RotateSpeed;
        }
    }
}