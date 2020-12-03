using System;
using System.Collections;
using System.Collections.Generic;
using Tweening.Scripts;
using Tweening.Scripts.Effects;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    Transform sphere;
    
    int cnt = 0;

    ITweenEffect effect;

    public void Scale()
    {
        if (cnt % 2 == 0)
        {
            effect = new MoveEffect(sphere, new Vector3(-5f,0f,0f), .5f, EaseType.CubicEaseOut);
            effect.OnComplete += OnEffectComplete;

            //effect = new ScaleRectEffect(GetComponent<RectTransform>(), Vector3.one * 2f, .5f, EaseType.CubicEaseOut);
        }
        else
        {
            effect = new MoveEffect(sphere, new Vector3(5f,0f,0f), .5f, EaseType.CubicEaseOut);
            effect.OnComplete += OnEffectComplete;
            
            //effect = new ScaleRectEffect(GetComponent<RectTransform>(), Vector3.one, .25f, EaseType.CubicEaseOut);
        }

        cnt++;
        
        StopAllCoroutines();
        StartCoroutine(effect.Execute());
    }

    void OnEffectComplete(ITweenEffect effect)
    {
        print($"Completed {effect}!");
    }
}
