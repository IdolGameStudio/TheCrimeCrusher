using System;
using UnityEngine;

namespace _Project.Scripts.StaticData.Enemy
{
    [Serializable]
    public class EnemyData
    {
        public EnemyType EnemyType;
        public float Damage;
        public float Speed;
        public float Health;
        public GameObject Prefab;
    }
}