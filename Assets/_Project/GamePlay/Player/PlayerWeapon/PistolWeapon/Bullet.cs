using UnityEngine;

namespace _Project.GamePlay.Player.PlayerWeapon.PistolWeapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 2f;
        private float _damage;
        private float _speed;
        private ObjectPool _pool;

        public float Damage => _damage;

        private void OnEnable() => 
            Invoke("ReturnToPool", _lifeTime);

        private void OnDisable() => 
            CancelInvoke();

        private void Update() => 
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        public void SetDamage(float damage) => 
            _damage = damage;

        public void SetSpeed(float speed) => 
            _speed = speed;

        public void SetPool(ObjectPool pool) => 
            _pool = pool;

        public void ReturnToPool() => 
            _pool.ReturnObject(gameObject);
    }
}