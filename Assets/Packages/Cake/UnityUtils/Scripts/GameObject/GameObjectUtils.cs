using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class GameObjectUtils
{
    public static T Instantiate<T>(this T p_model, string p_name = null) where T : MonoBehaviour
    {
        return p_model.gameObject.Instantiate(p_name).GetComponent<T>();
    }

    public static GameObject Instantiate(this GameObject p_model, string p_name = null)
    {
        Transform parent = null;
        return Instantiate(p_model, parent, p_name);
    }

    public static T Instantiate<T>(this T p_model, GameObject p_parent, string p_name = null) where T : Behaviour
    {
        return p_model.gameObject.Instantiate(p_parent, p_name).GetComponent<T>();
    }

    public static GameObject Instantiate(this GameObject p_model, GameObject p_parent, string p_name = null)
    {
        return Instantiate(p_model, p_parent.transform, p_name);
    }

    public static T Instantiate<T>(this T p_model, Transform p_parent, string p_name = null) where T : Behaviour
    {
        return p_model.gameObject.Instantiate(p_parent, p_name).GetComponent<T>();
    }

    public static GameObject Instantiate(this GameObject p_model, Transform p_parent, string p_name = null)
    {
        GameObject result = GameObject.Instantiate(p_model);
        if (!string.IsNullOrEmpty(p_name))
        {
            result.name = p_name;
        }
        else
        {
            result.name = p_model.name;
        }

        result.transform.SetParent(p_parent);
        return result;
    }
}