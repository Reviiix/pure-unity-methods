using System.Collections.Generic;
using UnityEngine;

public static class CollectionUtilities
{
    public static List<T> ShuffleList<T>(List<T> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            var randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }
    
    public static T[] ShuffleArray<T>(T[] list)
    {
        for (var i = 0; i < list.Length; i++)
        {
            var temp = list[i];
            var randomIndex = Random.Range(i, list.Length);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }
}
