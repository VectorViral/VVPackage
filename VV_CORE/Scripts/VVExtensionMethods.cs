// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

using System.Collections.Generic;
using UnityEngine;
using VectorViral.Tweening;

namespace VectorViral.Core
{
    public static class VVExtensionMethods
    {
        public static void ResetTransformation(this Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = new Vector3(1, 1, 1);
        }

        public static void CopyTransform(this Transform trans, Transform copyFrom)
        {
            trans.localPosition = copyFrom.localPosition;
            trans.localRotation = copyFrom.localRotation;
            trans.localScale = copyFrom.localScale;
        }

        public static void CopyParent(this Transform trans, Transform copyFrom)
        {
            trans.parent = copyFrom.parent;
        }

        public static Color HEXToColor(this string hexString)
        {
            Color c;
            ColorUtility.TryParseHtmlString(hexString, out c);
            return c;
        }

        public static List<string> DeepCopy(this List<string> fromList)
        {
            if (fromList == null) return null;
            List<string> copied = new List<string>();
            foreach (string s in fromList)
                copied.Add(s);
            return copied;
        }

        public static List<int> DeepCopy(this List<int> fromList)
        {
            if (fromList == null) return null;
            List<int> copied = new List<int>();
            foreach (int s in fromList)
                copied.Add(s);
            return copied;
        }

        public static List<float> DeepCopy(this List<float> fromList)
        {
            if (fromList == null) return null;
            List<float> copied = new List<float>();
            foreach (int s in fromList)
                copied.Add(s);
            return copied;
        }

        public static void DoPingPongScale(this GameObject obj, float fromScale, float toScale, float duration, float startWait = 0f, bool once = false)
        {
            int loop = -1;
            if (once)
                loop = 1;
            VVTween.Sequence()
                .Append(
                    obj.transform.DOScale(toScale, duration)
                )
                .Append(
                    obj.transform.DOScale(fromScale, duration)
                ).SetLoops(loop, LoopType.Yoyo).SetDelay(startWait);
        }

        public static void DoPingPongScale(this GameObject obj, Vector3 fromScale, Vector3 toScale, float duration, float startWait = 0f, bool once = false)
        {
            int loop = -1;
            if (once)
                loop = 1;
            VVTween.Sequence()
                .Append(
                    obj.transform.DOScale(toScale, duration)
                )
                .Append(
                    obj.transform.DOScale(fromScale, duration)
                ).SetLoops(loop, LoopType.Yoyo).SetDelay(startWait);
        }

        public static void DoCurveMove(this GameObject obj, Vector3 startPoint, Vector3 curvePoint, Vector3 endPoint, float duration, float startWait = 0f)
        {
            Vector3[] path = new Vector3[3];

            path[0] = startPoint;
            path[1] = curvePoint;
            path[2] = endPoint;

            obj.transform.DOPath(path, duration, PathType.CatmullRom).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log("Movement completed."));
        }
    }
}
