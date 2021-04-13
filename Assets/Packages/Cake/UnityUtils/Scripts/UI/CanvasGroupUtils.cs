using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public static class CanvasGroupUtils
{
    public static void Show(this CanvasGroup p_group)
    {
        p_group.alpha = 1f;
        p_group.interactable = true;
        p_group.blocksRaycasts = true;
    }

    public static void Hide(this CanvasGroup p_group)
    {
        p_group.alpha = 0f;
        p_group.interactable = false;
        p_group.blocksRaycasts = false;
    }
}