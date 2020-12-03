using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts.Effects
{
    public class RotateEffect: ITweenEffect
    {
        public event Action<ITweenEffect> OnComplete;
        
        Transform Transform { get; }
        
        Vector3 ToRotation { get; }
        
        float Duration { get; }
        
        EaseType Ease { get; }

        public RotateEffect(Transform transform, Vector3 toRotation, float duration, EaseType ease, Action<ITweenEffect> onComplete = null)
        {
            Transform = transform;
            ToRotation = toRotation;
            Duration = duration;
            Ease = ease;
            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            var time = 0f;
            var currentRotation = Transform.localEulerAngles;

            while (time < Duration)
            {
                time += Time.deltaTime;
                var t = time / Duration;
                
                var ease = new Ease();
                t = ease.CalculateEasing(t, Ease);

                var rotation = Vector3.Lerp(currentRotation, ToRotation, t);
                Transform.localEulerAngles = rotation;
                yield return null;
            }
            
            OnComplete?.Invoke(this);
        }
    }
}
