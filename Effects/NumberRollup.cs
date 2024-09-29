using System;
using System.Collections;
using TMPro;

namespace pure_unity_methods.Effects
{
    /// <summary>
    /// This class will incrementally change one value until it reaches another value and display it in the supplied text component.
    /// </summary>
    public static class NumberRollup 
    {
        public static IEnumerator Rollup(TMP_Text display, long originalValue, long newValue, string prefix, string suffix, float seconds, Action callBack = null)
        {
            if (originalValue == newValue)
            {
                callBack?.Invoke();
                yield break;
            }
            const float timeIncrement = 0.01f;
            float value = originalValue;
            var difference = newValue - value;
            var amountOfLoops = seconds / timeIncrement;
            var valueIncrement = difference / amountOfLoops;
            while (seconds > 0)
            {
                seconds-=timeIncrement;
                value+=valueIncrement;
                display.text = prefix + value.ToString("F0") + suffix;
                yield return null;
            }
            display.text = prefix + newValue + suffix;
            callBack?.Invoke();
        }
    }
}
