using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.Enemy
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public List<EnemyData> Enemies;
    }
}