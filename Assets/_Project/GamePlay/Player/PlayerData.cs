using UnityEngine;

namespace _Project.GamePlay.Player
{
    public class PlayerData: MonoBehaviour
    {
        [SerializeField] private float _speed = 0.5f;

        public float Speed => _speed;
    }
}