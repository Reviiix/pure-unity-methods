using System;
using System.Collections;
using UnityEngine;

namespace pure_unity_methods
{
   /// <summary>
   /// The static wait class is intended to hold all generic waiting co routines that can be used throughout the application.
   /// </summary>
   public static class Wait
   {
      public static IEnumerator WaitThenCallBack(float seconds, Action callBack)
      {
         yield return new WaitForSeconds(seconds);
         callBack();
      }
   }
}
