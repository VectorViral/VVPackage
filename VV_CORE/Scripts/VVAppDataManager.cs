// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.Core
{
    using Newtonsoft.Json;
    using UnityEngine;

    public class VVAppDataManager : MonoBehaviour
    {
        private const string appDataKey = "vvAppData";
        private const string legacyAppDataKey = "mrAppData";

        [SerializeField]
        VVApp app;

        public static VVAppDataManager Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            DontDestroyOnLoad(this.gameObject);
            Initialize();
        }

        public void Initialize()
        {
            string keyToUse = PlayerPrefs.HasKey(appDataKey) ? appDataKey : (PlayerPrefs.HasKey(legacyAppDataKey) ? legacyAppDataKey : null);

            if (!string.IsNullOrEmpty(keyToUse))
            {
                string jsonSaved = PlayerPrefs.GetString(keyToUse);
                if (!string.IsNullOrEmpty(jsonSaved))
                {
                    try
                    {
                        app = JsonConvert.DeserializeObject<VVApp>(jsonSaved);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogWarning("VVAppDataManager: Failed to parse saved app data: " + ex.Message);
                        app = new VVApp();
                        app.Initialize();
                    }
                }
                else
                {
                    app = new VVApp();
                    app.Initialize();
                }
            }
            else
            {
                app = new VVApp();
                app.Initialize();
            }

            SaveAppData();
        }

        public void SaveAppData()
        {
            SerializeAndSave();
        }

        void SerializeAndSave()
        {
            if (app != null)
            {
                string jsonString = JsonConvert.SerializeObject(app);
                if (!string.IsNullOrEmpty(jsonString) && !jsonString.Contains("null"))
                {
                    PlayerPrefs.SetString(appDataKey, jsonString);
                    PlayerPrefs.Save();
                }
            }
        }

        public VVApp GetAppInstance()
        {
            return this.app;
        }
    }
}
