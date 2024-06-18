using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon.PistolWeapon
{
    public class PistolData : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _timeBetweenShots;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _range;
        [SerializeField] private int _maxBullet;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private AudioClip _shootSound;
        [SerializeField] private GameObject _bulletPrefab;

        public int MaxBullet => _maxBullet;
        public float TimeBetweenShots => _timeBetweenShots;
        public float ReloadTime => _reloadTime;
        public float Range => _range;
        public float Damage => _damage;
        public float BulletSpeed => _bulletSpeed;

        public AudioClip ShootSound => _shootSound;

        public GameObject BulletPrefab => _bulletPrefab;
    }
}