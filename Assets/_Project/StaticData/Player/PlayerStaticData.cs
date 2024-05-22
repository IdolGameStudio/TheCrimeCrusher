using UnityEngine;

namespace _Project.StaticData.Player
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/PlayerStaticData")]
    public class PlayerStaticData: ScriptableObject
    {
        public float MoveSpeed;
        public float RotateSpeed;
        public GameObject Prefab;
    }
}