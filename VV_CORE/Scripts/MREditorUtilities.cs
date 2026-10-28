 
#if UNITY_EDITOR
namespace VectorViral.Core
{
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Events;

    public static class MREditorUtilities
    {
        [MenuItem("VVPackage/VV Editor Utilities/Delete Preferences %#-")]
        static void DeletePreferences()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            Caching.ClearCache();
            Debug.Log("MREditorUtilities: Preferences Deleted");
        }

        public static GUIStyle GetLabelStyle(GUIStyle gs, Color color, int fontSize = 12, int paddingLeft = 0)
        {
            GUIStyle style = new GUIStyle(gs);
            style.normal.textColor = color;
            style.fontSize = fontSize;
            style.wordWrap = true;
            style.padding.left = paddingLeft;
            return style;
        }

        public static void CreateIconButton(Texture2D icon, int width, int height, UnityAction onClicked)
        {
            Rect iconRect = GUILayoutUtility.GetRect(width, height, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
            GUI.DrawTexture(iconRect, icon, ScaleMode.ScaleToFit);
            Event e = Event.current;
            if (e.type == EventType.MouseDown && e.button == 0 && iconRect.Contains(e.mousePosition))
                onClicked?.Invoke();
        }

        public static void DrawColoredSeparator(Color color, float height)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, height, EditorStyles.boldLabel);
            rect.height = height;

            EditorGUI.DrawRect(rect, color);
        }

        public static List<T> GetAssetsByType<T>(string optionalNamespace = "") where T : Object
        {
            string[] guids = AssetDatabase.FindAssets("t:" + optionalNamespace + "." + typeof(T).Name);
            List<T> assets = new List<T>();

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                T asset = AssetDatabase.LoadAssetAtPath<T>(path);

                if (asset != null)
                    assets.Add(asset);
            }

            return assets;
        }

        public static List<Object> GetAssetsByFilter(string filter)
        {
            string[] guids = AssetDatabase.FindAssets(filter);
            List<Object> assets = new List<Object>();

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                Object asset = AssetDatabase.LoadAssetAtPath<Object>(path);

                if (asset != null)
                    assets.Add(asset);
            }

            return assets;
        }

        public static bool IsStringInLines(List<string> lines, string s)
        {
            foreach (string line in lines)
                if (line.Contains(s))
                    return true;
            return false;
        }

        /// <summary>
        /// Returns the list of guids of all the script files that match the script name. Don't supply the extension
        /// </summary>
        /// <param name="scriptName"></param>
        /// <returns></returns>
        public static List<string> GetAssetGuidsByFilter(string filter)
        {
            return AssetDatabase.FindAssets(filter).ToList();
        }

        /// <summary>
        /// Returns the path of the first asset that's found on the filter
        /// </summary>
        /// <param name="scriptName"></param>
        /// <returns></returns>
        public static string GetAssetPathByFilter(string filter)
        {
            string[] guids = AssetDatabase.FindAssets(filter);
            if (guids != null && guids.Length > 0)
                return AssetDatabase.GUIDToAssetPath(guids[0]);
            return string.Empty;
        }
    }
}
#endif