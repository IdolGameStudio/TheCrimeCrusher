using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.StaticData.Weapon;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GamePlay.Player.PlayerWeapon.PistolWeapon
{
    public class PistolData : MonoBehaviour
    {
        [SerializeField] private WeaponID _id;
        [SerializeField] private Pistol _pistol;
        private float _damage;
        private float _timeBetweenShots;
        private float _reloadTime;
        private float _range;
        private int _bulletsCount;
        private float _bulletSpeed;
        private AudioClip _shootSound;
        private GameObject _bulletPrefab;
        private IStaticDataService _staticDataService;

        public int BulletsCount => _bulletsCount;
        public float TimeBetweenShots => _timeBetweenShots;
        public float ReloadTime => _reloadTime;
        public float Range => _range;
        public float Damage => _damage;
        public float BulletSpeed => _bulletSpeed;

        public AudioClip ShootSound => _shootSound;

        public GameObject BulletPrefab => _bulletPrefab;

        [Inject]
        private void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Upgrade(int level)
        {
            _bulletsCount = _staticDataService.GetWeaponData(_id).WeaponData[level].BulletsCount;
            _timeBetweenShots = _staticDataService.GetWeaponData(_id).WeaponData[level].TimeBetweenShots;
            _reloadTime = _staticDataService.GetWeaponData(_id).WeaponData[level].ReloadTime;
            _range = _staticDataService.GetWeaponData(_id).WeaponData[level].Range;
            _damage = _staticDataService.GetWeaponData(_id).WeaponData[level].Damage;
            _bulletSpeed = _staticDataService.GetWeaponData(_id).WeaponData[level].BulletSpeed;
            _shootSound = _staticDataService.GetWeaponData(_id).ShootSound;
            _bulletPrefab = _staticDataService.GetWeaponData(_id).BulletPrefab;
            _pistol.InitializeValues();
        }
    }
}