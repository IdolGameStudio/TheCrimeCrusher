using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.HUD.Weapons
{
    public class WeaponItemController : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void SetIcon(Sprite sprite) => _image.sprite = sprite;
    }
}