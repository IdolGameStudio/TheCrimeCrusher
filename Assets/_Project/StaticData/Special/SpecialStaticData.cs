using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData.Special
{
    [CreateAssetMenu(fileName = "Special", menuName = "StaticData/Special")]
    public class SpecialStaticData: ScriptableObject
    {
        public SpecialID SpecialID;
        public Sprite SpecialIcon;
        public AudioClip SpecialSound;
        public List<SpecialData> Specials;
        
    }
}