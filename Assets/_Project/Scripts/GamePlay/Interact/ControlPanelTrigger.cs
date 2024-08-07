using _Project.Scripts.GamePlay.Player;
using UnityEngine;

namespace _Project.Scripts.GamePlay.Interact
{
    public class ControlPanelTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _panelOnFX;
        [SerializeField] private InteractOnOff _interactObject;
        [SerializeField] private float _timeToInteract = 2f;
        
        private float _currentTime;
        private bool _isInteract = false;
        private bool _isInteractOn = false;

        private void Update()
        {
            if(!_isInteract) return;
            if(_isInteractOn) return;
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeToInteract)
            {
                _isInteractOn = true;
                _panelOnFX.SetActive(false);
                _interactObject.Interact();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.GetComponent<PlayerTag>()) return;
            _isInteract = true;
            _panelOnFX.SetActive(true);
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.GetComponent<PlayerTag>()) return;
            _currentTime = 0;
            _isInteract = false;
            _isInteractOn = false;
            _panelOnFX.SetActive(false);
        }
    }
}