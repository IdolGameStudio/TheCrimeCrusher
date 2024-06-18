using _Project.GamePlay.CharacterSM;
using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon.PistolWeapon
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private PlayerSM _playerSM;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private FindNearbyTarget _targetFinder;

        [SerializeField] private PistolData _pistolData;
        
        [SerializeField] private PistolBulletSpawner _bulletSpawner;

        private float _currentTimeBetweenShots;
        private float _reloadTimer;
        private int _currentBullet;
        private GameObject _target;

        private bool _isAiming;
        private bool _isReloading;

        private void Start()
        {
            InitializeValues();
        }

        private void InitializeValues()
        {
            _currentTimeBetweenShots = 0;
            _reloadTimer = 0;
            _currentBullet = _pistolData.MaxBullet;
            _bulletSpawner.SetWeaponData(_pistolData);
        }

        private void Update()
        {
            UpdateTimers();
            CheckReload();
            CheckShoot();
        }

        private void UpdateTimers()
        {
            _currentTimeBetweenShots -= Time.deltaTime;
            _reloadTimer -= Time.deltaTime;
        }

        private void CheckReload()
        {
            if (_reloadTimer <= 0 && _isReloading)
            {
                _isReloading = false;
            }
        }

        private void CheckShoot()
        {
            _target = _targetFinder.FindTarget();
            if (_target == null || _isReloading) return;

            if (_currentTimeBetweenShots <= 0)
            {
                Shoot();
                if (_currentBullet <= 0) Reload();
            }
        }

        private void Shoot()
        {
            _currentTimeBetweenShots = _pistolData.TimeBetweenShots;
            _currentBullet--;

            _bulletSpawner.ShootAtTarget(_target);
        }

        private void Reload()
        {
            _isReloading = true;
            _reloadTimer = _pistolData.ReloadTime;
            _currentBullet = _pistolData.MaxBullet;
        }
    }
}