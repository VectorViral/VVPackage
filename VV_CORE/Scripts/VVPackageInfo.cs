
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
        public List<MRDependency> dependencies;
    }

    [System.Serializable]
    public class MRDependency
    {
        public string package;
        public string version;
    }
}
