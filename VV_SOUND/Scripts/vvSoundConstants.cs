// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.Sound
{
    public static class vvSoundConstants
    {
        public static string VV_SOUND_LOGO = "Assets/VVPackage/VV_SOUND/Sprites/logo-vvsound.png";
        public static string SOUNDS = "Sounds";
        public static string VV_SOUNDS_FILENAME = "vvSounds.cs";
        public static string CLIPS = "Clips";
        public static string VV_SOUNDS_FILE_ASSET_FILTER = "vvSounds t:script";
        public static string VV_SOUNDS_FILE_STARTCODE = "#if VV_SOUND\nnamespace VectorViral.Sound\n{\n\tpublic class vvSounds {\n";
        public static string VV_SOUNDS_FILE_ENDCODE = "\t}\n}\n#endif";
        public static string VV_SOUNDS_FILE_LINE = "\t\tpublic static string {} = \"{}\";\n";
        public static string DUPLICATE_SOUNDS_FOUND = "Duplicate unique sound names found. Please remove duplicates";
        public static string DUPLICATE_SOUND_FILE_NAME = "Duplicate name. A sound file with this unique name already exists";
        public static string VV_SOUND_NAME_EMPTY = "Sound name can't be empty";
    }
}
