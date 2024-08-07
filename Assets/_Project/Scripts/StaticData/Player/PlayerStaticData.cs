using UnityEngine;

namespace _Project.Scripts.StaticData.Player
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "StaticData/PlayerStaticData")]
    public class PlayerStaticData: ScriptableObject
    {
        public float WalkSpeed;
        public float RotateSpeed;
        public GameObject Prefab;
    }
}