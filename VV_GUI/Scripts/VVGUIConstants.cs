// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

using System.Collections.Generic;

namespace VectorViral.GUI
{
    public static class VVGUIConstants
    {
        public static string VV_GUI_LOGO = "Assets/VVPackage/VV_GUI/Sprites/logo-vvgui.png";
        public static string VV_SCREENS_FILE_ASSET_FILTER = "VVScreens t:script";
        public static string VV_SCREENS_FILENAME = "VVScreens.cs";
        public static string NEW_VV_SCREEN_PREFIX = "VVScreen_";
        public static string SCREENS = "Screens";
        public static string CANVAS_OBJECT = "Canvas ";
        public static string CONTAINER = "Container";
        public static string IN_CANVAS = "In Canvas";
        public static string FULL_SCREEN = "Full";
        public static string FIRST_SCREEN = "First";
        public static string NEWLY_CREATED_VV_SCREEN = "newlyCreatedVVScreen";
        public static string VVGUIMANAGER = "VVGUIManager ";
        public static string VV_SOUNDS_FILE_STARTCODE = "#if VV_GUI\nnamespace VectorViral.GUI\n{\n\tpublic class VVScreens {\n";
        public static string VV_SCREENS_FILE_LINE = "\t\tpublic static string {} = \"{}\";";
        public static string VV_SCREENS_FILE_ENDCODE = "\t}\n}\n#endif";
        public static string ENTER_VALID_SCREEN_FILE_NAME = "Enter a valid screen file name";
        public static string DUPLICATE_SCREEN_FILE_NAME = "Duplicate screen name. A screen script with this name already exists";
        public static List<string> VV_SCREENS_REPLACE_STRINGS = new List<string>{
            "#if VV_GUI",
            "namespace VectorViral.GUI",
            "public class VVScreens {",
            "#endif",
            "{",
            "}"
        };

        public static readonly string VV_SCREEN_CLASS_CODE = @"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VectorViral.Tweening;
using UnityEngine.UI;
using VectorViral.GUI;

public class **CLASSNAME** : VVScreen
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

#region Default VVScreen Methods
    /// <summary>
    /// PreShow is called before a VVScreen becomes visible. Use this to make your screen elements ready to be displayed / animated.
    /// </summary>
    public override void PreShow()
    {

    }

    /// <summary>
    /// Show is called once a VVScreen becomes visible. Use this to animate your screen, set data, begin screen functionality.
    /// </summary>
    public override void Show()
    {

    }

    /// <summary>
    /// PreHide is called before a VVScreen becomes invisible. Use this to make your closing / outro animations
    /// </summary>
    public override void PreHide(VVScreenEvent onComplete)
    {
        // Raising this event is necessary to continue the UI flow, don't remove this line.
        base.RaiseVVScreenEvent(onComplete, 0f);
    }

    // Hide is called once a VVScreen becomes invisible. Use this for custom scenarios (if any).
    public override void Hide()
    {

    }
#endregion
}";
    }
}
