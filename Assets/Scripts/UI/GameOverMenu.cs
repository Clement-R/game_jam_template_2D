using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Cake.Millefeuille;

public class GameOverMenu : Menu
{
    [SerializeField] private Button m_restartButton;
    [SerializeField] private Button m_mainMenuButton;

    private GameManager m_gameManager;

    void Start()
    {
        m_gameManager = Container.Get<GameManager>();

        m_restartButton.onClick.AddListener(Restart);
        m_mainMenuButton.onClick.AddListener(GoToMainMenu);

        m_gameManager.GameState.OnValueChanged += GameStateChanged;
    }

    private void OnDestroy()
    {
        m_gameManager.GameState.OnValueChanged -= GameStateChanged;
    }

    private void GameStateChanged(EGameState p_state)
    {
        if (p_state == EGameState.GAME_OVER)
        {
            m_group.alpha = 1f;
            m_group.interactable = true;
            m_group.blocksRaycasts = true;
        }
        else
        {
            m_group.alpha = 0f;
            m_group.interactable = false;
            m_group.blocksRaycasts = false;
        }
    }

    private void Restart()
    {
        m_gameManager.GameState.Value = EGameState.GAME;
        //TODO: ask level manager to reload current level
    }

    private void GoToMainMenu()
    {
        m_gameManager.GameState.Value = EGameState.MAIN_MENU;
    }
}