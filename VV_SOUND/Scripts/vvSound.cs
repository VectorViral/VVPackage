 
namespace VectorViral.Sound
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "mrSound", menuName = "VV Package/VV Sound/Create Sound")]
    [System.Serializable]
    public class vvSound : ScriptableObject
    {
        public string uniqueName;
        public List<AudioClip> clips;
        [Range(0, 1)]
        public float volume = 1;
        [Range(0, 3)]
        public float pitch = 1;
    }
}
 