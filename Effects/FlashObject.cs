using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace pure_unity_methods.Effects
{
    /// <summary>
    /// This class will turn objects on and off intermittently.
    /// Use the appropriate method for your object as theres no need to be working with Game Objects when we can work with smaller components
    /// </summary>
    public static class FlashObject
    {
        public static IEnumerator FlashGraphic(Graphic renderer, float cycles, WaitForSeconds waitFlashTime, Action completionCallBack = null)
        {
            for (var i = 0; i < cycles; i++)
            {
                renderer.enabled = !renderer.enabled;
                yield return waitFlashTime;
            }
            renderer.enabled = true;
            completionCallBack?.Invoke();
        }
        
        public static IEnumerator FlashGameObject(GameObject objectToFlash, float cycles, WaitForSeconds waitFlashTime, Action completionCallBack = null)
        {
            for (var i = 0; i < cycles; i++)
            {
                objectToFlash.SetActive(!objectToFlash.activeInHierarchy);
                yield return waitFlashTime;
            }
            objectToFlash.SetActive(true);
            completionCallBack?.Invoke();
        }
    }
}
