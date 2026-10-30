// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.Sound
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "vvSound", menuName = "VV Package/VV Sound/Create VV Sound")]
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
