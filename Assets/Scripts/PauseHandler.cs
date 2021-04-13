using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Cake.Millefeuille;

public class PauseHandler : MonoBehaviour
{
    private GameManager m_gameManager;

    void Start()
    {
        m_gameManager = Container.Get<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_gameManager.GameState.Value = EGameState.PAUSE;
        }
    }
}