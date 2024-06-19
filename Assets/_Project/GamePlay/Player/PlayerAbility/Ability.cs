using UnityEngine;

namespace _Project.GamePlay.Player.PlayerAbility
{
    public abstract class Ability : MonoBehaviour
    {
        public abstract void Activate();
        protected abstract void UpdateAbility();

        private void Update() =>
            UpdateAbility();
    }
}