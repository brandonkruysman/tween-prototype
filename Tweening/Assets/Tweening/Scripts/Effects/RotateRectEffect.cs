using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts.Effects
{
    public class RotateRectEffect: ITweenEffect
    {
        public event Action<ITweenEffect> OnComplete;
        RectTransform RectTransform { get; }
        
        Vector3 ToRotation { get; }
        float Duration { get; }
        
        EaseType Ease { get; }

        public RotateRectEffect(RectTransform rectTransform, Vector3 toRotation, float duration, EaseType ease, Action<ITweenEffect> onComplete = null)
        {
            RectTransform = rectTransform;
            ToRotation = toRotation;
            Duration = duration;
            Ease = ease;
            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            var time = 0f;
            var currentRotation = RectTransform.localEulerAngles;

            while (time < Duration)
            {
                time += Time.deltaTime;
                var t = time / Duration;
                
                var ease = new Ease();
                t = ease.CalculateEasing(t, Ease);

                var rotation = Vector3.Lerp(currentRotation, ToRotation, t);
                RectTransform.localEulerAngles = rotation;
                yield return null;
            }
            
            OnComplete?.Invoke(this);
        }
    }
}
