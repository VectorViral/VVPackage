namespace VectorViral.Core
{
    using Newtonsoft.Json;
    using UnityEngine;

    public class VVAppDataManager : MonoBehaviour
    {
        private const string appDataKey = "mrAppData";
        [SerializeField]
        MRApp app;

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
            if (PlayerPrefs.HasKey(appDataKey))
            {
                string jsonSaved = PlayerPrefs.GetString(appDataKey);
                if (!string.IsNullOrEmpty(jsonSaved))
                {
                    try
                    {
                        app = JsonConvert.DeserializeObject<MRApp>(jsonSaved);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogWarning("VVAppDataManager: Failed to parse saved app data: " + ex.Message);
                        app = new MRApp();
                        app.Initialize();
                    }
                }
                else
                {
                    app = new MRApp();
                    app.Initialize();
                }
            }
            else
            {
                app = new MRApp();
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

        public MRApp GetAppInstance()
        {
            return this.app;
        }
    }

    // Backward-compatibility alias for existing scripts and prefabs
    public class MRAppDataManager : VVAppDataManager { }
}
