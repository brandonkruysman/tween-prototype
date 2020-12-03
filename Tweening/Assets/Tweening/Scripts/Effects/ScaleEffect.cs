using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts.Effects
{
    public class ScaleEffect: ITweenEffect
    {
        public event Action<ITweenEffect> OnComplete;
        
        Transform Transform { get; }
        
        Vector3 ToScale { get; }
        
        float Duration { get; }
        
        EaseType Ease { get; }

        public ScaleEffect(Transform transform, Vector3 toScale, float duration, EaseType ease, Action<ITweenEffect> onComplete = null)
        {
            Transform = transform;
            ToScale = toScale;
            Duration = duration;
            Ease = ease;
            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            var time = 0f;
            var currentScale = Transform.localScale;

            while (time < Duration)
            {
                time += Time.deltaTime;
                var t = time / Duration;
                
                var ease = new Ease();
                t = ease.CalculateEasing(t, Ease);

                var scale = Vector3.Lerp(currentScale, ToScale, t);
                Transform.localScale = scale;
                yield return null;
            }
            
            OnComplete?.Invoke(this);
        }
    }
}
