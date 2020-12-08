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

    public void Move()
    {
        if (cnt % 2 == 0)
        {
            effect = new MoveEffect(sphere, new Vector3(-5f,0f,0f), .5f, EaseType.CubicEaseOut);
            effect.OnComplete += OnEffectComplete;
        }
        else
        {
            effect = new MoveEffect(sphere, new Vector3(5f,0f,0f), .5f, EaseType.CubicEaseOut);
            effect.OnComplete += OnEffectComplete;
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
