using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class ListUtils
{
    public static T Random<T>(this List<T> p_list)
    {
        return p_list[UnityEngine.Random.Range(0, p_list.Count)];
    }
}