using UnityEngine;

namespace _Project.Scripts.GamePlay.Player.PlayerAbility.Drone
{
    public class DroneAttackData : MonoBehaviour
    {
        [SerializeField] private string _abilityName;
        [SerializeField] private float _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _speed;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _duration;
        [SerializeField] private float _attackInterval;
        [SerializeField] private GameObject _dronePrefab;

        public string AbilityName => _abilityName;

        public float Cooldown => _cooldown;

        public float Duration => _duration;

        public float AttackInterval => _attackInterval;

        public GameObject DronePrefab => _dronePrefab;

        public float Damage => _damage;

        public float Range => _range;

        public float Speed => _speed;
    }
}