using UnityEngine;
using Zenject;

namespace _Project.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {



        public class Factory : PlaceholderFactory<HUDRoot>
        {
            
        }
    }
}