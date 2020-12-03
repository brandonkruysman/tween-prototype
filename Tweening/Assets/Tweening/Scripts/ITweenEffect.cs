using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening.Scripts
{
    public interface ITweenEffect
    {
        IEnumerator Execute();
        
        event Action<ITweenEffect> OnComplete;
    } 
}

