using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Cake.Millefeuille;

public class PauseTest : MonoBehaviour
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
            m_gameManager.Pause.Value = !m_gameManager.Pause.Value;
        }
    }
}