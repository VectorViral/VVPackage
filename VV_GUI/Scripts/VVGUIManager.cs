// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

#if MR_GUI
namespace VectorViral.GUI
{
    using UnityEngine;
    using System.Collections.Generic;
    using DG.Tweening;
    using UnityEngine.UI;
    using VectorViral.Core;
 
 

    public class VVGUIManager : MonoBehaviour
    {
        [Tooltip("Serialized references to MRScreen components in the scene to avoid expensive runtime search.")]
        [SerializeField] private List<MRScreen> screens = new List<MRScreen>();
        Stack<MRScreen> stack = new Stack<MRScreen>();
        MRScreen currentScreen = null;
        public delegate void GUIEvent();
        public float transitionSmoothness = 0.25f;
        GameObject blocker;
        bool isGUIStarted = false;

        string source = "";

        public static VVGUIManager Instance;
        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            // Use serialized references from inspector to improve performance
            if (screens == null || screens.Count == 0)
            {
#if UNITY_2023_1_OR_NEWER
                screens = new List<MRScreen>(FindObjectsByType<MRScreen>(FindObjectsInactive.Include, FindObjectsSortMode.None));
#elif UNITY_2020_1_OR_NEWER
                screens = new List<MRScreen>(FindObjectsOfType<MRScreen>(true));
#else
                screens = new List<MRScreen>(FindObjectsOfType(typeof(MRScreen)) as MRScreen[]);
#endif
            }

            foreach (MRScreen screen in screens)
            {
                if (screen != null && screen.container != null)
                    screen.container.SetActive(false);
            }

            blocker = new GameObject();
            blocker.transform.parent = this.transform;
            blocker.name = "MRGUIBlockerCanvas";
            blocker.AddComponent<Canvas>();
            blocker.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            blocker.GetComponent<Canvas>().sortingOrder = 1000;
            blocker.AddComponent<CanvasScaler>();
            blocker.AddComponent<GraphicRaycaster>();
            blocker.SetActive(false);

            GameObject i = new GameObject();
            i.name = "MRGUIBlockerImage";
            i.transform.parent = blocker.transform;
            i.transform.ResetTransformation();
            i.AddComponent<Image>();
            i.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            i.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            i.GetComponent<RectTransform>().anchorMax = Vector2.one;
            i.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            i.GetComponent<Image>().sprite = null;
            Color c = i.GetComponent<Image>().color;
            c.a = 0;
            i.GetComponent<Image>().color = c;
            i.transform.localScale = Vector3.one;

            Application.targetFrameRate = 60;
            Application.runInBackground = false;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void OnEnable()
        {
#if MR_REMOTE_CONFIGURATIONS
            MRRemoteConfigurationsManager.OnRemoteConfigReady += StartGUI;
#endif
        }

        private void OnDisable()
        {
#if MR_REMOTE_CONFIGURATIONS
            MRRemoteConfigurationsManager.OnRemoteConfigReady -= StartGUI;
#endif
        }

        private void Start()
        {
#if MR_REMOTE_CONFIGURATIONS
            if (MRRemoteConfigurationsManager.Instance)
            {
                if (MRRemoteConfigurationsManager.Instance.IsRemoteConfigReady())
                    StartGUI();
            }
            else
#endif
                StartGUI();
        }

     

        private void StartGUI()
        {
            if (isGUIStarted) return;
            isGUIStarted = true;

            foreach (MRScreen screen in screens)
                screen.gameObject.SetActive(false);

            stack.Clear();
            MRScreen firstScreen = screens.Find(p => p.isFirstScreen);
            if (firstScreen != null)
            {
                stack.Push(firstScreen);
                ShowStackPeek();
            }

          
        }

        public void Open(string screenName, GUIEvent onComplete)
        {
        
            source = "";
            if (currentScreen != null)
                source = currentScreen.screenName;

            if (currentScreenName == screenName)
                return;

            MRScreen screenToOpen = screens.Find(p => p.GetComponent<MRScreen>().screenName == screenName);
            if (screenToOpen != null)
            {
                screenToOpen.container.SetActive(false);
                screenToOpen.container.GetComponent<CanvasGroup>().alpha = 0f;

                if (screenToOpen.isFullScreen && currentScreen != null && currentScreen.gameObject.activeSelf)
                {
                    blocker.SetActive(true);
                    currentScreen.onPreHide.Invoke();
                    currentScreen.PreHide(() =>
                    {
                        OpenWorker(screenToOpen, true, onComplete);
                        blocker.SetActive(false);
                    });
                }
                else
                    OpenWorker(screenToOpen, false, onComplete);
            }
            else
                Debug.LogError(screenName + " Screen Not Detected By VVGUIManager");
        }

        void OpenWorker(MRScreen screen, bool closePrevious, GUIEvent onComplete)
        {
            if (closePrevious)
            {
                currentScreen.onHide.Invoke();
                currentScreen.Hide();
                currentScreen.gameObject.SetActive(false);
                currentScreen.container.SetActive(false);
            }

            stack.Push(screen);
            ShowStackPeek();
            if (onComplete != null)
                onComplete();
          
        }

        void ShowStackPeek()
        {
            currentScreen = stack.Peek();



            float introFadeTime =
                currentScreen.hasIntroSmoothness ?
                    currentScreen.overrideSmoothness?
                    currentScreen.overrideSmoothnessValue : transitionSmoothness :
                0f;

            currentScreen.container.GetComponent<CanvasGroup>().DOFade(1f, introFadeTime);
            if (currentScreen.introAnimation == MRScreenAnimationType.None)
                currentScreen.container.transform.localPosition = Vector3.zero;
            else
            {
                RectTransform rect = currentScreen.container.GetComponent<RectTransform>();
                RectTransform canvasRect = currentScreen.transform.parent.GetComponent<RectTransform>();
                float minX = -(canvasRect.sizeDelta.x - rect.sizeDelta.x);
                float maxX = (canvasRect.sizeDelta.x - rect.sizeDelta.x);
                float minY = -(canvasRect.sizeDelta.y - rect.sizeDelta.y);
                float maxY = (canvasRect.sizeDelta.y - rect.sizeDelta.y);

                Vector3 pos = currentScreen.container.transform.localPosition;
                if (currentScreen.introAnimation == MRScreenAnimationType.RTL)
                    pos.x = maxX;
                else if (currentScreen.introAnimation == MRScreenAnimationType.LTR)
                    pos.x = minX;
                else if (currentScreen.introAnimation == MRScreenAnimationType.Drop)
                    pos.y = maxY;
                else if (currentScreen.introAnimation == MRScreenAnimationType.Rise)
                    pos.y = minY;

                currentScreen.container.transform.DOLocalMove(pos, 0f);

                float moveTime = currentScreen.hasIntroSmoothness ?
                    currentScreen.overrideSmoothness ?
                    currentScreen.overrideSmoothnessValue : transitionSmoothness :
                0f;

                currentScreen.container.transform.DOLocalMove(Vector3.zero, moveTime).SetEase(currentScreen.introEase);
            }

            currentScreen.gameObject.SetActive(true);

            currentScreen.onPreShow.Invoke();
            currentScreen.PreShow();
            currentScreen.container.SetActive(true);
            currentScreen.onShow.Invoke();
            currentScreen.Show();

#if MR_ANALYTICS
            if (MRAnalyticsManager.Instance)
                MRAnalyticsManager.Instance.LogScreenView(currentScreen.screenName, source);
#endif
        }

        public void Back(GUIEvent onCompleted = null)
        {
           

            source = "";
            if (currentScreen != null)
                source = currentScreen.screenName;

            if (stack != null)
            {
                if (stack.Count > 1)
                    CloseWorker(onCompleted, true);
                else
                    Application.Quit();
            }
        }

        public MRScreen GetScreenByName(string name)
        {
            return this.screens.Find(p => p.screenName == name);
        }

        public void Restart()
        {
            isGUIStarted = false;

            foreach (MRScreen screen in screens)
            {
                if (screen.container != null)
                    screen.container.SetActive(false);
                screen.gameObject.SetActive(false);
            }
            StartGUI();
        }

        public void Close(GUIEvent onCompleted = null)
        {
            Debug.Log("C L O S E");

            source = "";
            if (currentScreen != null)
                source = currentScreen.screenName;

            CloseWorker(onCompleted, false);
        }

        void CloseWorker(GUIEvent onCompleted, bool closeAndBack = false)
        {
            blocker.SetActive(true);
            currentScreen.onPreHide.Invoke();
            currentScreen.PreHide(() =>
            {
                currentScreen.onHide.Invoke();
                currentScreen.Hide();
                currentScreen.container.SetActive(false);
                currentScreen.gameObject.SetActive(false);
                blocker.SetActive(false);
                stack.Pop();
                if (closeAndBack)
                    ShowStackPeek();
                else
                    currentScreen = stack.Peek();

                if (onCompleted != null)
                    onCompleted.Invoke();

                
            });
        }

        public GameObject currentScreenObject
        {
            get
            {
                if (currentScreen != null)
                    return currentScreen.gameObject;
                else
                {
                    Debug.LogError("Current Screen Null");
                    return null;
                }
            }
        }

        public MRScreen GetCurrentScreen()
        {
            if(currentScreen == null)
                Debug.LogError("Current Screen Null");
            return currentScreen;
        }

        public string currentScreenName
        {
            get
            {
                if (stack != null && stack.Count > 0 && currentScreen != null)
                    return currentScreen.screenName;
                return "";
            }
        }

#if UNITY_EDITOR
        private void Reset()
        {
            PopulateScreens();
        }

        private void OnValidate()
        {
            if (screens == null || screens.Count == 0)
            {
                PopulateScreens();
            }
        }

        private void PopulateScreens()
        {
#if UNITY_2023_1_OR_NEWER
            screens = new List<MRScreen>(FindObjectsByType<MRScreen>(FindObjectsInactive.Include, FindObjectsSortMode.None));
#elif UNITY_2020_1_OR_NEWER
            screens = new List<MRScreen>(FindObjectsOfType<MRScreen>(true));
#else
            screens = new List<MRScreen>(FindObjectsOfType(typeof(MRScreen)) as MRScreen[]);
#endif
        }
#endif
    }
    // end of class


    // Backwards compatibility alias
    public class MRGUIManager : VVGUIManager { }
}
#endif