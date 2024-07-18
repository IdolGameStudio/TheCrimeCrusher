using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.HUD.Special
{
    public class SpecialItemController : MonoBehaviour
    {
        [SerializeField] private Image _specialIcon;
        
        public void SetIcon(Sprite sprite) => _specialIcon.sprite = sprite;
    }
}