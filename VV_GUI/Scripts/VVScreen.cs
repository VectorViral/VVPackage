// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.GUI
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;
    using VectorViral.Tweening;

    public delegate void VVScreenEvent();

    public abstract class VVScreen : MonoBehaviour
    {
        [Header("--- VV Screen Details ---")]
        public string screenName;
        public bool isFullScreen;
        public bool isFirstScreen;
        public bool hasIntroSmoothness = false;
        public bool hasOutroSmoothness = false;
        public bool overrideSmoothness = false;
        public float overrideSmoothnessValue = 0.25f;
        public VVScreenAnimationType introAnimation = VVScreenAnimationType.None;
        public Ease introEase = Ease.Linear;
        public VVScreenAnimationType outroAnimation = VVScreenAnimationType.None;
        public Ease outroEase = Ease.Linear;
        public GameObject container;

        public abstract void PreShow();
        public abstract void Show();
        public abstract void PreHide(VVScreenEvent onComplete);
        public abstract void Hide();

        public UnityEvent onPreShow, onShow, onPreHide, onHide;

        /// <summary>
        /// Raises a VVScreenEvent after the waitTime
        /// </summary>
        /// <param name="screenEvent"></param>
        /// <param name="waitTime"></param>
        public void RaiseVVScreenEvent(VVScreenEvent screenEvent, float waitTime)
        {
            StartCoroutine(CallCompleteEventWorker(screenEvent, waitTime));
        }

        IEnumerator CallCompleteEventWorker(VVScreenEvent screenEvent, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            float finalWait = 0f;

            float smoothness = hasOutroSmoothness ?
                    overrideSmoothness ?
                    overrideSmoothnessValue : VVGUIManager.Instance.transitionSmoothness :
                0f;

            if (hasOutroSmoothness || outroAnimation != VVScreenAnimationType.None)
                finalWait = smoothness;

            if (hasOutroSmoothness && container != null)
            {
                var cg = container.GetComponent<CanvasGroup>();
                if (cg != null) cg.DOFade(0f, smoothness);
            }
            if (outroAnimation != VVScreenAnimationType.None && container != null && transform.parent != null)
            {
                RectTransform rect = container.GetComponent<RectTransform>();
                RectTransform canvasRect = transform.parent.GetComponent<RectTransform>();
                if (rect != null && canvasRect != null)
                {
                    float minX = -(canvasRect.sizeDelta.x - rect.sizeDelta.x);
                    float maxX = (canvasRect.sizeDelta.x - rect.sizeDelta.x);
                    float minY = -(canvasRect.sizeDelta.y - rect.sizeDelta.y);
                    float maxY = (canvasRect.sizeDelta.y - rect.sizeDelta.y);

                    Vector3 pos = container.transform.localPosition;
                    if (outroAnimation == VVScreenAnimationType.RTL)
                        pos.x = minX;
                    else if (outroAnimation == VVScreenAnimationType.LTR)
                        pos.x = maxX;
                    else if (outroAnimation == VVScreenAnimationType.Drop)
                        pos.y = minY;
                    else if (outroAnimation == VVScreenAnimationType.Rise)
                        pos.y = maxY;

                    container.transform.DOLocalMove(pos, smoothness).SetEase(outroEase);
                }
            }

            yield return new WaitForSeconds(finalWait);
            screenEvent?.Invoke();
        }
    }
}
