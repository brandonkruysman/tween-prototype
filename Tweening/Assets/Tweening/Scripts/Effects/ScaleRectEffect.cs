using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts.Effects
{
    public class ScaleRectEffect: ITweenEffect
    {
        public event Action<ITweenEffect> OnComplete;
        RectTransform RectTransform { get; }
        Vector3 MaxSize { get; }
        float Duration { get; }
        
        EaseType Ease { get; }

        public ScaleRectEffect(RectTransform rectTransform, Vector3 maxSize, float duration, EaseType ease, Action<ITweenEffect> onComplete = null)
        {
            RectTransform = rectTransform;
            MaxSize = maxSize;
            Duration = duration;
            Ease = ease;
            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            var time = 0f;
            var currentScale = RectTransform.localScale;

            while (time < Duration)
            {
                time += Time.deltaTime;
                var t = time / Duration;
                
                var ease = new Ease();
                t = ease.CalculateEasing(t, Ease);

                var scale = Vector3.Lerp(currentScale, MaxSize, t);
                RectTransform.localScale = scale;
                yield return null;
            }
            
            OnComplete?.Invoke(this);
        }
    }
}
