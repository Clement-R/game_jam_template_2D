using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform m_follow;
    [SerializeField] bool m_onX;
    [SerializeField] bool m_onY;

    void Start()
    {

    }

    void Update()
    {
        if (m_follow == null) return;

        if (m_onX)
        {
            transform.position = Vector3Int.FloorToInt(transform.position.SetX(m_follow.transform.position.x));
        }

        if (m_onY)
        {
            transform.position = Vector3Int.FloorToInt(transform.position.SetY(m_follow.transform.position.y));
        }
    }
}