// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "packageInfo", menuName = "VV Package/VV Core/Create Package Info")]
    public class VVPackageInfo : ScriptableObject
    {
        public string displayName;
        public string folderName;
        public string version;
        public string information;
        public DateTime releaseDate;
        public string exportName;
        public List<string> exports;
        public List<VVDependency> dependencies;
    }

    [System.Serializable]
    public class VVDependency
    {
        public string package;
        public string version;
    }
}
