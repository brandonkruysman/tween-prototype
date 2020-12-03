using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts.Effects
{
    public class MoveRectEffect: ITweenEffect
    {
        public event Action<ITweenEffect> OnComplete;
        RectTransform RectTransform { get; }
        
        Vector3 ToPosition { get; }
        float Duration { get; }
        
        EaseType Ease { get; }

        public MoveRectEffect(RectTransform rectTransform, Vector3 toPosition, float duration, EaseType ease, Action<ITweenEffect> onComplete = null)
        {
            RectTransform = rectTransform;
            ToPosition = ToPosition;
            Duration = duration;
            Ease = ease;
            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            var time = 0f;
            var currentPosition = RectTransform.position;

            while (time < Duration)
            {
                time += Time.deltaTime;
                var t = time / Duration;
                
                var ease = new Ease();
                t = ease.CalculateEasing(t, Ease);

                var position = Vector3.Lerp(currentPosition, ToPosition, t);
                RectTransform.position = position;
                yield return null;
            }
            
            OnComplete?.Invoke(this);
        }
    }
}
