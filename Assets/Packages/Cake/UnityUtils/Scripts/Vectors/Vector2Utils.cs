using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class Vector2Utils
{
    public static Vector2 SetX(this Vector2 p_vector, float p_float)
    {
        return new Vector2(p_float, p_vector.y);
    }

    public static Vector2 SetY(this Vector2 p_vector, float p_float)
    {
        return new Vector2(p_vector.x, p_float);
    }
}