namespace VectorViral.Core
{
#if MR_CORE
    using Newtonsoft.Json;
#endif
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

#if MR_REMOTE_CONFIGURATIONS
            if (FindObjectOfType<MRRemoteConfigurationsManager>() == null)
                Initialize();
#else
            Initialize();
#endif
        }

        public void Initialize()
        {
            if (PlayerPrefs.HasKey(appDataKey))
            {
                string jsonSaved = PlayerPrefs.GetString(appDataKey);
#if MR_CORE
                app = JsonConvert.DeserializeObject<MRApp>(PlayerPrefs.GetString(appDataKey));
#endif
            }
            else
            {
                app = new MRApp();
                app.Initialize();
                SaveAppData();

#if MR_ANALYTICS
                MRAnalyticsManager.Instance.LogEvent("appDownload");
#endif
            }

            SaveAppData();
        }

        public void SaveAppData()
        {
#if MR_REMOTE_CONFIGURATIONS
            if (MRRemoteConfigurationsManager.Instance)
            {
                if (MRRemoteConfigurationsManager.Instance.IsRemoteConfigReady())
                    SerializeAndSave();
            }
            else
#endif
                SerializeAndSave();
        }

        void SerializeAndSave()
        {
#if MR_CORE
            string jsonString = JsonConvert.SerializeObject(app);
            if (!jsonString.Contains("null"))
                PlayerPrefs.SetString(appDataKey, JsonConvert.SerializeObject(app));
#endif
        }

        public MRApp GetAppInstance()
        {
            return this.app;
        }
    }

    // Backward-compatibility alias for existing scripts and prefabs
    public class MRAppDataManager : VVAppDataManager { }
}
