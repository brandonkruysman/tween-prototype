using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts.Effects
{
    public class MoveEffect: ITweenEffect
    {
        public event Action<ITweenEffect> OnComplete;
        
        Transform Transform { get; }
        
        Vector3 ToPosition { get; }
        
        float Duration { get; }
        
        EaseType Ease { get; }

        public MoveEffect(Transform transform, Vector3 toPosition, float duration, EaseType ease, Action<ITweenEffect> onComplete = null)
        {
            Transform = transform;
            ToPosition = toPosition;
            Duration = duration;
            Ease = ease;
            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            var time = 0f;
            var currentPosition = Transform.position;

            while (time < Duration)
            {
                time += Time.deltaTime;
                var t = time / Duration;
                
                var ease = new Ease();
                t = ease.CalculateEasing(t, Ease);

                var position = Vector3.Lerp(currentPosition, ToPosition, t);
                Transform.position = position;
                yield return null;
            }
            
            OnComplete?.Invoke(this);
        }
    }
}
