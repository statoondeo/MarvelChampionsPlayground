using System;
using System.Collections.Generic;

using UnityEngine;
public static class Easings
{
    public enum Method
    {
        Linear,
        QuintIn,
        QuintOut,
        QuintInOut
    }
    public static Func<float, float> Get(Method animation) => EasingDictionary[animation];
    private static readonly IDictionary<Method, Func<float, float>> EasingDictionary = new Dictionary<Method, Func<float, float>>()
        {
            { Method.Linear, EaseLinear },
            { Method.QuintIn, EaseInQuint },
            { Method.QuintOut, EaseOutQuint },
            { Method.QuintInOut, EaseInOutQuint }
        };

    private static float EaseLinear(float progress) => progress;

    #region Quint

    private static float EaseInQuint(float progress) => Mathf.Pow(progress, 5);
    private static float EaseOutQuint(float progress) => 1 - Mathf.Pow(1 - progress, 5);
    private static float EaseInOutQuint(float progress) 
        => progress < 0.5 ? 16 * Mathf.Pow(progress, 5) : 1 - Mathf.Pow(-2 * progress + 2, 5) / 2;

    #endregion
}