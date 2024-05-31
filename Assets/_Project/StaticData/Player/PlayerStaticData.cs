using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.StaticData.Player
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/PlayerStaticData")]
    public class PlayerStaticData: ScriptableObject
    {
        public float WalkSpeed;
        public float RotateSpeed;
        public GameObject Prefab;
    }
}