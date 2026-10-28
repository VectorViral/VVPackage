 
namespace VectorViral.GUI
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;
    using DG.Tweening;


    public delegate void MRScreenEvent();
    public abstract class MRScreen : MonoBehaviour
    {
     
        [Header("--- MR Screen Details ---")]
        public string screenName;
        public bool isFullScreen;
        public bool isFirstScreen;
        public bool hasIntroSmoothness = false;
        public bool hasOutroSmoothness = false;
        public bool overrideSmoothness = false;
        public float overrideSmoothnessValue = 0.25f;
        public MRScreenAnimationType introAnimation = MRScreenAnimationType.None;
        public Ease introEase = Ease.Linear;
        public MRScreenAnimationType outroAnimation = MRScreenAnimationType.None;
        public Ease outroEase = Ease.Linear;
        public GameObject container;

        public abstract void PreShow();
        public abstract void Show();
        public abstract void PreHide(MRScreenEvent onComplete);
        public abstract void Hide();

        public UnityEvent onPreShow, onShow, onPreHide, onHide;

        /// <summary>
        /// Raises an MRScreenEvent after the waitTime
        /// </summary>
        /// <param name="screenEvent"></param>
        /// <param name="waitTime"></param>
        public void RaiseMRScreenEvent(MRScreenEvent screenEvent, float waitTime)
        {
            StartCoroutine(CallCompleteEventWorker(screenEvent, waitTime));
        }

        IEnumerator CallCompleteEventWorker(MRScreenEvent screenEvent, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            float finalWait = 0f;

            float smoothness = hasOutroSmoothness ?
                    overrideSmoothness ?
                    overrideSmoothnessValue : VVGUIManager.Instance.transitionSmoothness :
                0f;

            if (hasOutroSmoothness || outroAnimation != MRScreenAnimationType.None)
                finalWait = smoothness;

            if (hasOutroSmoothness)
                container.GetComponent<CanvasGroup>().DOFade(0f, smoothness);
            if (outroAnimation != MRScreenAnimationType.None)
            {
                RectTransform rect = container.GetComponent<RectTransform>();
                RectTransform canvasRect = transform.parent.GetComponent<RectTransform>();
                float minX = -(canvasRect.sizeDelta.x - rect.sizeDelta.x);
                float maxX = (canvasRect.sizeDelta.x - rect.sizeDelta.x);
                float minY = -(canvasRect.sizeDelta.y - rect.sizeDelta.y);
                float maxY = (canvasRect.sizeDelta.y - rect.sizeDelta.y);

                Vector3 pos = container.transform.localPosition;
                if (outroAnimation == MRScreenAnimationType.RTL)
                    pos.x = minX;
                else if (outroAnimation == MRScreenAnimationType.LTR)
                    pos.x = maxX;
                else if (outroAnimation == MRScreenAnimationType.Drop)
                    pos.y = minY;
                else if (outroAnimation == MRScreenAnimationType.Rise)
                    pos.y = maxY;

                container.transform.DOLocalMove(pos, smoothness).SetEase(outroEase);
            }

            yield return new WaitForSeconds(finalWait);
            screenEvent();
        }
    }
}
 