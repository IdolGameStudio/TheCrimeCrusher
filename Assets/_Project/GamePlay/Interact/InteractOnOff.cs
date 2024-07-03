using UnityEngine;

namespace _Project.GamePlay.Interact
{
    public class InteractOnOff : MonoBehaviour
    {
        [SerializeField] private bool _onOffState;
        
        public void Interact()
        {
            _onOffState = !_onOffState;
            gameObject.SetActive(_onOffState);
        }
    }
}