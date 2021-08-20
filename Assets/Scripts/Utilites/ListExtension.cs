﻿using System.Collections.Generic;
using UnityEngine;

namespace Utilites
{
    public static class ListExtension
    {
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}