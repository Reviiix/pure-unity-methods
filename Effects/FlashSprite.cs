using System;
using System.Collections;
using UnityEngine;

namespace pure_unity_methods.Effects
{
    public static class FlashSprite
    {
        public static IEnumerator Flash(SpriteRenderer renderer, float cycles, WaitForSeconds flashTime, Action completionCallBack)
        {
            for (var i = 0; i < cycles; i++)
            {
                renderer.enabled = !renderer.enabled;
                yield return flashTime;
            }
            renderer.enabled = true;
            completionCallBack();
        }
    }
}
