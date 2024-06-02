using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData.Enemy
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public List<EnemyData> Enemies;
    }
}