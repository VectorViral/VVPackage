 
namespace VectorViral.Sound
{
    public static class MRSoundConstants
    {
        public static string MR_SOUND_LOGO = "Assets/VVPackage/VV_SOUND/Sprites/logo-mrsound.png";
        
        public static string SOUNDS = "Sounds";
        public static string MR_SOUNDS_FILENAME = "MRSounds.cs";
        public static string CLIPS = "Clips";
        public static string MR_SOUNDS_FILE_ASSET_FILTER = "MRSounds t:script";
        public static string MR_SOUNDS_FILE_STARTCODE = "#if MR_SOUND\nnamespace VectorViral.Sound\n{\n\tpublic class MRSounds {\n";
        public static string MR_SOUNDS_FILE_ENDCODE = "\t}\n}\n#endif";
        public static string MR_SOUNDS_FILE_LINE = "\t\tpublic static string {} = \"{}\";\n";
        public static string DUPLICATE_SOUNDS_FOUND = "Duplicate unique sound names found. Please remove duplicates";
        public static string DUPLICATE_SOUND_FILE_NAME = "Duplicate name. A sound file with this unique name already exists";
        public static string MR_SOUND_NAME_EMPTY = "Sound name can't be empty";
    }
}
 