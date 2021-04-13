using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Cake.Millefeuille;

public class GameOverTest : MonoBehaviour
{
    private GameManager m_gameManager;

    void Start()
    {
        m_gameManager = Container.Get<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            m_gameManager.GameState.Value = EGameState.GAME_OVER;
        }
    }
}