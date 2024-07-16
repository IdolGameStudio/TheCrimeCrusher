using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.HUD.Weapons
{
    public class WeaponItemController : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;

        public void SetIcon(Sprite sprite) => _itemImage.sprite = sprite;
    }
}