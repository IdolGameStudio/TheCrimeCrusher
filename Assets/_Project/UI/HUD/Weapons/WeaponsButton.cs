using _Project.StaticData.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.HUD.Weapons
{
    public class WeaponsButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private WeaponID _id;
        [SerializeField] private HUDRoot _hudRoot;
        
        

        private void Awake() => 
            _button.onClick.AddListener(() => _hudRoot.ChangeWeapon(_id));
    }
}