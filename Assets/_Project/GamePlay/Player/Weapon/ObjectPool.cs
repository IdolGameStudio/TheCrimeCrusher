using System.Collections.Generic;
using UnityEngine;

namespace _Project.GamePlay.Player.Weapon
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _initialSize = 10;

        private Queue<GameObject> _pool = new Queue<GameObject>();

        public void SetPrefab(GameObject prefab)
        {
            _prefab = prefab;
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