using System;
using System.Collections;
using UnityEngine;

namespace PureFunctions.Movement
{
    public static class RotateObject
    {
        public static IEnumerator Rotate(Transform rotatingObject, float speed, int rotations, float endValue, Action callBack)
        {
            const int fullRotation = 360;
            var value = rotatingObject.transform.rotation.z;
            var rotation = new Vector3();

            while (rotations > 0)
            {
                while (value < fullRotation)
                {
                    value += Time.deltaTime * speed;
                    rotation.z = value;
                    rotatingObject.transform.localEulerAngles = rotation;
                    speed *= 1.2f;
                    yield return null;
                }
                rotations--;
            }

            while (value < endValue)
            {
                value += Time.deltaTime * speed;
                rotation.z = value;
                rotatingObject.transform.localEulerAngles = rotation;
            }
            rotation.z = endValue;
            rotatingObject.transform.localEulerAngles = rotation;
            callBack();

        }
        
    }
}
