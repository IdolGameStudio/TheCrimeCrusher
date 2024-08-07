using _Project.Scripts.GamePlay.CharacterSM;
using UnityEngine;

namespace _Project.Scripts.GamePlay.Enemy
{
    public class AnimatorEvent : MonoBehaviour
    {
        [SerializeField] private EnemySM _enemySM;

        public void GetHitEnded()
        {
            _enemySM.ChangeState(_enemySM.CombatIdleState);
        }
    }
}