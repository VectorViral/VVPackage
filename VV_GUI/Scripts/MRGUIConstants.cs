 
 
using System.Collections.Generic;

namespace VectorViral.GUI
{
    public static class MRGUIConstants
    {
        public static string MR_GUI_LOGO = "Assets/VVPackage/MR_GUI/Sprites/logo-mrgui.png";
        public static string MR_SCREENS_FILE_ASSET_FILTER = "MRScreens t:script";
        public static string MR_SCREENS_FILENAME = "MRScreens.cs";
        public static string NEW_MR_SCREEN_PREFIX = "MRScreen_";
        public static string SCREENS = "Screens";
        public static string CANVAS_OBJECT = "Canvas ";
        public static string CONTAINER = "Container";
        public static string IN_CANVAS = "In Canvas";
        public static string FULL_SCREEN = "Full";
        public static string FIRST_SCREEN = "First";
        public static string NEWLY_CREATED_MR_SCREEN = "newlyCreatedMRScreen";
        public static string VVGUIMANAGER = "VVGUIManager ";
        public static string MR_SOUNDS_FILE_STARTCODE = "#if MR_GUI\nnamespace VectorViral.GUI\n{\n\tpublic class MRScreens {\n";
        public static string MR_SCREENS_FILE_LINE = "\t\tpublic static string {} = \"{}\";";
        public static string MR_SCREENS_FILE_ENDCODE = "\t}\n}\n#endif";
        public static string ENTER_VALID_SCREEN_FILE_NAME = "Enter a valid screen file name";
        public static string DUPLICATE_SCREEN_FILE_NAME = "Duplicate screen name. A screen script with this name already exists";
        public static List<string> MR_SCREENS_REPLACE_STRINGS = new List<string>{
            "#if MR_GUI",
            "namespace VectorViral.GUI",
            "public class MRScreens {",
            "#endif",
            "{",
            "}"
        };

        public static readonly string MR_SCREEN_CLASS_CODE = @"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using VectorViral.GUI;

public class **CLASSNAME** : MRScreen
{
    private void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

#region Default MRScreen Methods
    /// <summary>
    /// PreShow is called before an MRScreen becomes visible. Use this to make your screen elements ready to be displayed / animated.
    /// </summary>
    public override void PreShow()
    {

    }

    /// <summary>
    /// Show is called once an MRScreen becomes visible. Use this to animate your screen, set data, begin screen functionality.
    /// </summary>
    public override void Show()
    {

    }

    /// <summary>
    /// PreHide is called before an MRScreen becomes invisible. Use this to make your closing / outro animations
    /// </summary>
    public override void PreHide(MRScreenEvent onComplete)
    {
        //Raising this event is necessary to continue the UI flow, don't remove this line.
        base.RaiseMRScreenEvent(onComplete, 0f);
    }

    // Hide is called once an MRScreen becomes invisible. Use this for custom scenarios (if any).
    public override void Hide()
    {

    }
#endregion
}";
    }
}
 