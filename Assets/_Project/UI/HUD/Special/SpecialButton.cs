using _Project.StaticData.Special;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.HUD.Special
{
    public class SpecialButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private SpecialID _id;
        [SerializeField] private HUDRoot _hudRoot;
        
        

        private void Awake() => 
            _button.onClick.AddListener(() => _hudRoot.UseSpecial(_id));
    }
}