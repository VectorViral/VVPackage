// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.Core
{
    public static class VVCoreConstants
    {
        public static string VV_CORE = "VV_CORE";
        public static string VV_GUI = "VV_GUI";
        public static string VV_SOUND = "VV_SOUND";
        public static string VV_FEEL = "VV_FEEL";
        public static string VV_ADS = "VV_ADS";
        public static string VV_ANALYTICS = "VV_ANALYTICS";
        public static string VV_LEADERBOARDS = "VV_LEADERBOARDS";
        public static string VV_REMOTE_CONFIGURATIONS = "VV_REMOTE_CONFIGURATIONS";
        public static string VV_IN_APP_PURCHASING = "VV_IN_APP_PURCHASING";
        public static string VV_NOTIFICATIONS = "VV_NOTIFICATIONS";

        // Backward compatibility constants
        public static string MR_CORE = "VV_CORE";
        public static string MR_GUI = "VV_GUI";
        public static string MR_SOUND = "VV_SOUND";
        public static string MR_FEEL = "VV_FEEL";
        public static string MR_ADS = "VV_ADS";
        public static string MR_ANALYTICS = "VV_ANALYTICS";
        public static string MR_LEADERBOARDS = "VV_LEADERBOARDS";
        public static string MR_REMOTE_CONFIGURATIONS = "VV_REMOTE_CONFIGURATIONS";
        public static string MR_IN_APP_PURCHASING = "VV_IN_APP_PURCHASING";
        public static string MR_NOTIFICATIONS = "VV_NOTIFICATIONS";

        public static string OKAY = "Okay";
        public static string ASSETS = "Assets";
        public static string PATH = "Path";
        public static string OPEN_EDITOR = "Open Editor";
        public static string NEW = "New";
        public static string VERSION_SHORT = "v";
        public static string REFRESH = "Refresh";
        public static string VERSION = "Version ";
        public static string SELECT = "Select";
        public static string INSTALLED = "Installed";
        public static string TYPE = "Type";
        public static string NOT_INSTALLED = "Not Installed";
        public static string ENABLE = "Enable";
        public static string DISABLE = "Disable";
        public static string NUMBER = "#";
        public static string NAME = "Name";
        public static string EXPORT = "Export";
        public static string CLOSE = "Close";
        public static string ERROR = "Error!";
        public static string NEW_FILE_PATH = "New Path : ";
        public static string CREATE_FILE = "Create File";
        public static string CREATE = "Create";
        public static string RELEASE_DATE = "Release Date: ";
        public static string EMPTY_RELEASE_NOTES = "New release notes can't be empty!";
        public static string EXPORT_DIRECTORY = "Assets";
        public static string EXPORT_TITLE = "Export Package";
        public static string PACKAGE_EXPORTED = "Package Exported Successfully!";
        public static string EXPORT_DETAILS_TITLE = "Export Details";
        public static string EXPORT_COMPLETE = "Package Exported Successfully!"; 
        public static string UNITY_PACKAGE_EXTENSION = "unitypackage";
        public static string PACKAGE_EXPORTED_MESSAGE = "package exported to ";
        public static string INCREMENT_VERSION = "New Version?";
        public static string ENTER_RELEASE_NOTES = "Enter New Release Notes:";
        public static string PREVIOUS_RELEASE_NOTES = "Previous Release Notes:";
        public static string END_OF_FILE = "End Of File";
        public static string SELECT_CORRECT_ASSETS_PATH = "Select a path with in the project Assets folder";
        public static string DUPLICATE_FILE = "Duplicate file. Already exists!";
        public static string FILE_NOT_FOUND = " File not found";
        public static string FILE_EXISTS = " File exists ";
        public static string FILE_ALREADY_EXISTS = " File already exists!";
        public static string FILE_ALREADY_EXISTS_IN_PROJECT = " File already exists in the project!";
        public static string DASHED_LINE = "-----------------------------------------------\n";

        public static string VV_CORE_LOGO = "Assets/VVPackage/VV_CORE/Sprites/logo-vvcore.png";
        public static string MR_CORE_LOGO = VV_CORE_LOGO;
        public static string VV_TICK_ICON = "Assets/VVPackage/VV_CORE/Sprites/icon-tick.png";
        public static string MR_TICK_ICON = VV_TICK_ICON;
        public static string VV_CROSS_ICON = "Assets/VVPackage/VV_CORE/Sprites/icon-cross.png";
        public static string MR_CROSS_ICON = VV_CROSS_ICON;
        public static string VV_EXPORT_ICON = "Assets/VVPackage/VV_CORE/Sprites/icon-export.png";
        public static string MR_EXPORT_ICON = VV_EXPORT_ICON;
        public static string VV_PLUS_ICON = "Assets/VVPackage/VV_CORE/Sprites/icon-plus.png";
        public static string MR_PLUS_ICON = VV_PLUS_ICON;
        public static string ICON_DELETE = "Assets/VVPackage/VV_CORE/Sprites/icon-delete.png";
        public static string ICON_PIN = "Assets/VVPackage/VV_CORE/Sprites/icon-pin.png";
        public static string PACKAGE_INFO_URL = "Assets/VVPackage/{}/packageInfo.asset";
        public static string RELEASE_NOTES_FILE_URL = "Assets/VVPackage/{}/releaseNotes.txt";
    }

    // Backward-compatibility alias
    public static class MRCoreConstants
    {
        public static string MR_CORE => VVCoreConstants.VV_CORE;
        public static string MR_GUI => VVCoreConstants.VV_GUI;
        public static string MR_SOUND => VVCoreConstants.VV_SOUND;
        public static string MR_FEEL => VVCoreConstants.VV_FEEL;
        public static string MR_ADS => VVCoreConstants.VV_ADS;
        public static string MR_ANALYTICS => VVCoreConstants.VV_ANALYTICS;
        public static string MR_LEADERBOARDS => VVCoreConstants.VV_LEADERBOARDS;
        public static string MR_REMOTE_CONFIGURATIONS => VVCoreConstants.VV_REMOTE_CONFIGURATIONS;
        public static string MR_IN_APP_PURCHASING => VVCoreConstants.VV_IN_APP_PURCHASING;
        public static string MR_NOTIFICATIONS => VVCoreConstants.VV_NOTIFICATIONS;
        public static string OKAY => VVCoreConstants.OKAY;
        public static string ASSETS => VVCoreConstants.ASSETS;
        public static string PATH => VVCoreConstants.PATH;
        public static string OPEN_EDITOR => VVCoreConstants.OPEN_EDITOR;
        public static string NEW => VVCoreConstants.NEW;
        public static string VERSION_SHORT => VVCoreConstants.VERSION_SHORT;
        public static string REFRESH => VVCoreConstants.REFRESH;
        public static string VERSION => VVCoreConstants.VERSION;
        public static string SELECT => VVCoreConstants.SELECT;
        public static string INSTALLED => VVCoreConstants.INSTALLED;
        public static string TYPE => VVCoreConstants.TYPE;
        public static string NOT_INSTALLED => VVCoreConstants.NOT_INSTALLED;
        public static string ENABLE => VVCoreConstants.ENABLE;
        public static string DISABLE => VVCoreConstants.DISABLE;
        public static string NUMBER => VVCoreConstants.NUMBER;
        public static string NAME => VVCoreConstants.NAME;
        public static string EXPORT => VVCoreConstants.EXPORT;
        public static string CLOSE => VVCoreConstants.CLOSE;
        public static string ERROR => VVCoreConstants.ERROR;
        public static string NEW_FILE_PATH => VVCoreConstants.NEW_FILE_PATH;
        public static string CREATE_FILE => VVCoreConstants.CREATE_FILE;
        public static string CREATE => VVCoreConstants.CREATE;
        public static string RELEASE_DATE => VVCoreConstants.RELEASE_DATE;
        public static string EMPTY_RELEASE_NOTES => VVCoreConstants.EMPTY_RELEASE_NOTES;
        public static string EXPORT_DIRECTORY => VVCoreConstants.EXPORT_DIRECTORY;
        public static string EXPORT_TITLE => VVCoreConstants.EXPORT_TITLE;
        public static string PACKAGE_EXPORTED => VVCoreConstants.PACKAGE_EXPORTED;
        public static string EXPORT_DETAILS_TITLE => VVCoreConstants.EXPORT_DETAILS_TITLE;
        public static string EXPORT_COMPLETE => VVCoreConstants.EXPORT_COMPLETE;
        public static string UNITY_PACKAGE_EXTENSION => VVCoreConstants.UNITY_PACKAGE_EXTENSION;
        public static string PACKAGE_EXPORTED_MESSAGE => VVCoreConstants.PACKAGE_EXPORTED_MESSAGE;
        public static string INCREMENT_VERSION => VVCoreConstants.INCREMENT_VERSION;
        public static string ENTER_RELEASE_NOTES => VVCoreConstants.ENTER_RELEASE_NOTES;
        public static string PREVIOUS_RELEASE_NOTES => VVCoreConstants.PREVIOUS_RELEASE_NOTES;
        public static string END_OF_FILE => VVCoreConstants.END_OF_FILE;
        public static string SELECT_CORRECT_ASSETS_PATH => VVCoreConstants.SELECT_CORRECT_ASSETS_PATH;
        public static string DUPLICATE_FILE => VVCoreConstants.DUPLICATE_FILE;
        public static string FILE_NOT_FOUND => VVCoreConstants.FILE_NOT_FOUND;
        public static string FILE_EXISTS => VVCoreConstants.FILE_EXISTS;
        public static string FILE_ALREADY_EXISTS => VVCoreConstants.FILE_ALREADY_EXISTS;
        public static string FILE_ALREADY_EXISTS_IN_PROJECT => VVCoreConstants.FILE_ALREADY_EXISTS_IN_PROJECT;
        public static string DASHED_LINE => VVCoreConstants.DASHED_LINE;
        public static string MR_CORE_LOGO => VVCoreConstants.VV_CORE_LOGO;
        public static string MR_TICK_ICON => VVCoreConstants.VV_TICK_ICON;
        public static string MR_CROSS_ICON => VVCoreConstants.VV_CROSS_ICON;
        public static string MR_EXPORT_ICON => VVCoreConstants.VV_EXPORT_ICON;
        public static string MR_PLUS_ICON => VVCoreConstants.VV_PLUS_ICON;
        public static string ICON_DELETE => VVCoreConstants.ICON_DELETE;
        public static string ICON_PIN => VVCoreConstants.ICON_PIN;
        public static string PACKAGE_INFO_URL => VVCoreConstants.PACKAGE_INFO_URL;
        public static string RELEASE_NOTES_FILE_URL => VVCoreConstants.RELEASE_NOTES_FILE_URL;
    }
}
