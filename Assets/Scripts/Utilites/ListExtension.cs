using System.Collections.Generic;
using UnityEngine;

namespace Utilites
{
    public static class ListExtension
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        
        public static T GetRandomAndRemove<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            var element = list[index];
            list.RemoveAt(index);
            return element;
        }
        
        public static T GetRandom<T>(this IReadOnlyList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}