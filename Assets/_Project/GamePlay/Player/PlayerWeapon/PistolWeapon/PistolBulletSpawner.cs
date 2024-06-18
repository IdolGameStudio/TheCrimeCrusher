using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon.PistolWeapon
{
    public class PistolBulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private ObjectPool _bulletPool;

        private AudioSource _shootSoundSource;
        private PistolData _weaponData;

        private void Awake()
        {
            _shootSoundSource = GetComponent<AudioSource>();
        }

        public void SetWeaponData(PistolData weaponData)
        {
            _weaponData = weaponData;

            if (_shootSoundSource != null && _weaponData.ShootSound != null)
            {
                _shootSoundSource.clip = _weaponData.ShootSound;
            }

            if (_bulletPool != null)
            {
                _bulletPool.SetPrefab(_weaponData.BulletPrefab);
            }
        }

        public void ShootAtTarget(GameObject target)
        {
            if (target == null || _weaponData == null)
            {
                return;
            }

            Vector3 direction = (target.transform.position - _firePoint.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject bullet = _bulletPool.GetObject();
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = rotation;

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDamage(_weaponData.Damage);
                bulletScript.SetSpeed(_weaponData.BulletSpeed);
                bulletScript.SetPool(_bulletPool);
            }

            PlayShootSound();
        }

        private void PlayShootSound()
        {
            if (_shootSoundSource != null && _shootSoundSource.clip != null)
            {
                _shootSoundSource.Play();
            }
        }
    }
}