using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Example.Light
{
    public class CameraBehaviour : MonoBehaviour
    {
        [SerializeField] private Follow m_follow;
        private GameManager m_gameManager;

        private void Start()
        {
            m_gameManager = GameManager.Instance;
            m_gameManager.GameState.OnValueChanged += GameStateChanged;
            GameStateChanged(m_gameManager.GameState.Value);
        }

        private void OnDestroy()
        {
            m_gameManager.GameState.OnValueChanged -= GameStateChanged;
        }

        private void GameStateChanged(EGameState p_state)
        {
            if (p_state == EGameState.GAME)
            {
                m_follow.enabled = true;
            }
            else
            {
                m_follow.enabled = false;
            }
        }
    }
}