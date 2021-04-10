using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class Vector3Utils
{
    public static Vector3 SetX(this Vector3 p_vector, float p_float)
    {
        return new Vector3(p_float, p_vector.y, p_vector.z);
    }

    public static Vector3 SetY(this Vector3 p_vector, float p_float)
    {
        return new Vector3(p_vector.x, p_float, p_vector.z);
    }

    public static Vector3 SetZ(this Vector3 p_vector, float p_float)
    {
        return new Vector3(p_vector.x, p_vector.y, p_float);
    }
}