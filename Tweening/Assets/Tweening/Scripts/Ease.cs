using System;
using UnityEngine;
using Math = UnityEngine.Mathf;

namespace Tweening.Scripts
{
    public class Ease
    {
	    
	    const float k_Pi = Mathf.PI; 
	    
	    const float k_HalfPi = Mathf.PI / 2.0f; 
	    
        public float CalculateEasing(float t, EaseType ease)
        {
            switch (ease)
            {
	            default:
	            case EaseType.Linear:  
		            return Linear(t);
	            case EaseType.QuadraticEaseOut:
		            return QuadraticEaseOut(t);
	            case EaseType.QuadraticEaseIn:			
		            return QuadraticEaseIn(t);
	            case EaseType.QuadraticEaseInOut:		
		            return QuadraticEaseInOut(t);
	            case EaseType.CubicEaseIn:				
		            return CubicEaseIn(t);
	            case EaseType.CubicEaseOut:			
		            return CubicEaseOut(t);
	            case EaseType.CubicEaseInOut:			
		            return CubicEaseInOut(t);
	            case EaseType.QuarticEaseIn:			
		            return QuarticEaseIn(t);
	            case EaseType.QuarticEaseOut:			
		            return QuarticEaseOut(t);
	            case EaseType.QuarticEaseInOut:		
		            return QuarticEaseInOut(t);
	            case EaseType.QuinticEaseIn:			
		            return QuinticEaseIn(t);
	            case EaseType.QuinticEaseOut:			
		            return QuinticEaseOut(t);
	            case EaseType.QuinticEaseInOut:		
		            return QuinticEaseInOut(t);
	            case EaseType.SineEaseIn:				
		            return SineEaseIn(t);
	            case EaseType.SineEaseOut:				
		            return SineEaseOut(t);
	            case EaseType.SineEaseInOut:			
		            return SineEaseInOut(t);
	            case EaseType.CircularEaseIn:			
		            return CircularEaseIn(t);
	            case EaseType.CircularEaseOut:			
		            return CircularEaseOut(t);
	            case EaseType.CircularEaseInOut:		
		            return CircularEaseInOut(t);
	            case EaseType.ExponentialEaseIn:		
		            return ExponentialEaseIn(t);
	            case EaseType.ExponentialEaseOut:		
		            return ExponentialEaseOut(t);
	            case EaseType.ExponentialEaseInOut:	
		            return ExponentialEaseInOut(t);
	            case EaseType.ElasticEaseIn:			
		            return ElasticEaseIn(t);
	            case EaseType.ElasticEaseOut:			
		            return ElasticEaseOut(t);
	            case EaseType.ElasticEaseInOut:		
		            return ElasticEaseInOut(t);
	            case EaseType.BackEaseIn:				
		            return BackEaseIn(t);
	            case EaseType.BackEaseOut:				
		            return BackEaseOut(t);
	            case EaseType.BackEaseInOut:			
		            return BackEaseInOut(t);
	            case EaseType.BounceEaseIn:			
		            return BounceEaseIn(t);
	            case EaseType.BounceEaseOut:			
		            return BounceEaseOut(t);
	            case EaseType.BounceEaseInOut:			
		            return BounceEaseInOut(t);
            }
        }
        
		static public float Linear(float t)
		{
			return t;
		}
		
		static public float QuadraticEaseIn(float t)
		{
			return t * t;
		}
		
		static public float QuadraticEaseOut(float t)
		{
			return -(t * (t - 2));
		}
		
		static public float QuadraticEaseInOut(float t)
		{
			if(t < 0.5f)
			{
				return 2 * t * t;
			}
			else
			{
				return (-2 * t * t) + (4 * t) - 1;
			}
		}
		
		static public float CubicEaseIn(float t)
		{
			return t * t * t;
		}
		
		static public float CubicEaseOut(float t)
		{
			float f = (t - 1);
			return f * f * f + 1;
		}
		
		static public float CubicEaseInOut(float t)
		{
			if(t < 0.5f)
			{
				return 4 * t * t * t;
			}
			else
			{
				float f = ((2 * t) - 2);
				return 0.5f * f * f * f + 1;
			}
		}
		
		static public float QuarticEaseIn(float t)
		{
			return t * t * t * t;
		}
		
		static public float QuarticEaseOut(float t)
		{
			float f = (t - 1);
			return f * f * f * (1 - t) + 1;
		}

		static public float QuarticEaseInOut(float t) 
		{
			if(t < 0.5f)
			{
				return 8 * t * t * t * t;
			}
			else
			{
				float f = (t - 1);
				return -8 * f * f * f * f + 1;
			}
		}
		
		static public float QuinticEaseIn(float t) 
		{
			return t * t * t * t * t;
		}
		
		static public float QuinticEaseOut(float t) 
		{
			float f = (t - 1);
			return f * f * f * f * f + 1;
		}
		
		static public float QuinticEaseInOut(float t) 
		{
			if(t < 0.5f)
			{
				return 16 * t * t * t * t * t;
			}
			else
			{
				float f = ((2 * t) - 2);
				return 0.5f * f * f * f * f * f + 1;
			}
		}
		
		static public float SineEaseIn(float t)
		{
			return (float)Math.Sin((t - 1) * k_HalfPi) + 1;
		}
		
		static public float SineEaseOut(float t)
		{
			return (float)Math.Sin(t * k_HalfPi);
		}
		
		static public float SineEaseInOut(float t)
		{
			return (float)(0.5f * (1 - Math.Cos(t * k_Pi)));
		}
		
		static public float CircularEaseIn(float t)
		{
			return (float)(1 - Math.Sqrt(1 - (t * t)));
		}
		
		static public float CircularEaseOut(float t)
		{
			return (float)(Math.Sqrt((2 - t) * t));
		}
		
		static public float CircularEaseInOut(float t)
		{
			if(t < 0.5f)
			{
				return (float)(0.5f * (1 - Math.Sqrt(1 - 4 * (t * t))));
			}
			else
			{
				return (float)(0.5f * (Math.Sqrt(-((2 * t) - 3) * ((2 * t) - 1)) + 1));
			}
		}
		
		static public float ExponentialEaseIn(float t)
		{
			return (t == 0.0f) ? t : (float)(Math.Pow(2, 10 * (t - 1)));
		}
		
		static public float ExponentialEaseOut(float t)
		{
			return (t == 1.0f) ? t : (float)(1 - Math.Pow(2, -10 * t));
		}
		
		static public float ExponentialEaseInOut(float t)
		{
			if(t == 0.0 || t == 1.0) return t;
			
			if(t < 0.5f)
			{
				return (float)(0.5f * Math.Pow(2, (20 * t) - 10));
			}
			else
			{
				return (float)(-0.5f * Math.Pow(2, (-20 * t) + 10) + 1);
			}
		}
		
		static public float ElasticEaseIn(float t)
		{
			return (float)(Math.Sin(13 * k_HalfPi * t) * Math.Pow(2, 10 * (t - 1)));
		}
		
		static public float ElasticEaseOut(float t)
		{
			return (float)(Math.Sin(-13 * k_HalfPi * (t + 1)) * Math.Pow(2, -10 * t) + 1);
		}
		
		static public float ElasticEaseInOut(float t)
		{
			if(t < 0.5f)
			{
				return (float)(0.5f * Math.Sin(13 * k_HalfPi * (2 * t)) * Math.Pow(2, 10 * ((2 * t) - 1)));
			}
			else
			{
				return (float)(0.5f * (Math.Sin(-13 * k_HalfPi * ((2 * t - 1) + 1)) * Math.Pow(2, -10 * (2 * t - 1)) + 2));
			}
		}
		
		static public float BackEaseIn(float t)
		{
			return (float)(t * t * t - t * Math.Sin(t * k_Pi));
		}
		
		static public float BackEaseOut(float t)
		{
			float f = (1 - t);
			return (float)(1 - (f * f * f - f * Math.Sin(f * k_Pi)));
		}
		
		static public float BackEaseInOut(float t)
		{
			if(t < 0.5f)
			{
				float f = 2 * t;
				return (float)(0.5f * (f * f * f - f * Math.Sin(f * k_Pi)));
			}
			else
			{
				float f = (1 - (2*t - 1));
				return (float)(0.5f * (1 - (f * f * f - f * Math.Sin(f * k_Pi))) + 0.5f);
			}
		}
		
		static public float BounceEaseIn(float t)
		{
			return 1 - BounceEaseOut(1 - t);
		}

		static public float BounceEaseOut(float t)
		{
			if(t < 4/11.0f)
			{
				return (121 * t * t)/16.0f;
			}
			else if(t < 8/11.0f)
			{
				return (363/40.0f * t * t) - (99/10.0f * t) + 17/5.0f;
			}
			else if(t < 9/10.0f)
			{
				return (4356/361.0f * t * t) - (35442/1805.0f * t) + 16061/1805.0f;
			}
			else
			{
				return (54/5.0f * t * t) - (513/25.0f * t) + 268/25.0f;
			}
		}
		
		static public float BounceEaseInOut(float t)
		{
			if(t < 0.5f)
			{
				return 0.5f * BounceEaseIn(t*2);
			}
			else
			{
				return 0.5f * BounceEaseOut(t * 2 - 1) + 0.5f;
			}
		}
    }
}
