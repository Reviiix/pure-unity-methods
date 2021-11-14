using System;
using System.Collections;
using TMPro;

namespace PureFunctions.Effects
{
    public static class NumberRolling 
    {
        public static IEnumerator Rollup(TMP_Text display, long originalValue, long newValue, string prefix, string suffix, float seconds, Action callBack = null)
        {
            const float timeIncrement = 0.01f;
            float value = originalValue;
            var difference = newValue - value;
            var amountOfLoops = seconds / timeIncrement;
            var valueIncrement = difference / amountOfLoops;
            while (seconds > 0)
            {
                seconds-=timeIncrement;
                value+=valueIncrement;
                display.text = prefix + value.ToString("N0") + suffix;
                yield return null;
            }
            display.text = prefix + newValue + suffix;
            callBack?.Invoke();
        }
        
        public static IEnumerator RollDown(TMP_Text display, long originalValue, long newValue, string prefix, string suffix, float seconds, Action callBack = null)
        {
            const float timeIncrement = 0.01f;
            float value = originalValue;
            var difference = newValue - value;
            var amountOfLoops = seconds / timeIncrement;
            var valueIncrement = difference / amountOfLoops;
            while (seconds > 0)
            {
                seconds-=timeIncrement;
                value-=valueIncrement;
                display.text = prefix + value.ToString("N0") + suffix;
                yield return null;
            }
            display.text = prefix + newValue + suffix;
            callBack?.Invoke();
        }
    }
}
