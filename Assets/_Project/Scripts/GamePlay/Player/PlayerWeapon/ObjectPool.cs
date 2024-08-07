using System.Collections.Generic;
using _Project.Scripts.GamePlay.Player.PlayerWeapon.PistolWeapon;
using UnityEngine;

namespace _Project.Scripts.GamePlay.Player.PlayerWeapon
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int _initialSize = 10;

        private GameObject _prefab;
        private Queue<GameObject> _pool = new Queue<GameObject>();
        private PistolData _pistolData;

        public void SetWeaponData(PistolData pistolData)
        {
            _pistolData = pistolData;
            _prefab = _pistolData.BulletPrefab;
            InitializePool();
        }

        private void InitializePool()
        {
            _pool.Clear();
            for (int i = 0; i < _initialSize; i++)
            {
                GameObject obj = Instantiate(_prefab);
                obj.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            if (_pool.Count > 0)
            {
                GameObject obj = _pool.Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                GameObject obj = Instantiate(_prefab);
                obj.SetActive(true);
                return obj;
            }
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}