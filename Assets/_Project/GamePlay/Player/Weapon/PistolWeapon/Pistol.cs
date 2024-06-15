using _Project.GamePlay.CharacterSM;
using _Project.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.GamePlay.Player.Weapon.PistolWeapon
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private PlayerSM _playerSM;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private FindNearbyTarget _targetFinder;

        [SerializeField] private float _damage;
        [SerializeField] private float _timeBetweenShots;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _range;
        [SerializeField] private int _maxBullet;

        private float _currentTimeBetweenShots;
        private float _reloadTimer;
        private int _currentBullet;
        private GameObject _target;

        private bool _isAiming;
        private bool _isReloading;

        private void Start()
        {
            _currentTimeBetweenShots = 0;
            _reloadTimer = 0;
        }

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
        }

        private void Update()
        {
            _target = _targetFinder.FindTarget();
            _currentTimeBetweenShots -= Time.deltaTime;
            _reloadTimer -= Time.deltaTime;
            if (_target == null) return;
            if (_reloadTimer <= 0 && _isReloading) 
                _isReloading = false;

            if (_currentTimeBetweenShots <= 0 && !_isReloading)
            {
                Shoot();
                if (_currentBullet <= 0) Reload();
            }
        }

        private void Shoot()
        {
                _currentTimeBetweenShots = _timeBetweenShots;
                _currentBullet--;
            
        }

        private void Reload()
        {
            _isReloading = true;
            _reloadTimer = _reloadTime;
            _currentBullet = _maxBullet;
        }
    }
}