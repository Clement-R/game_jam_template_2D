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
    [SerializeField] private SceneReference m_mainMenuScene;

    private GameManager m_gameManager;
    private ScenesManager m_scenesManager;

    void Start()
    {
        m_gameManager = Container.Get<GameManager>();
        m_scenesManager = Container.Get<ScenesManager>();

        m_restartButton.onClick.AddListener(Restart);
        m_mainMenuButton.onClick.AddListener(GoToMainMenu);

        m_gameManager.GameState.OnValueChanged += GameStateChanged;

        m_group.Hide();
    }

    private void OnDestroy()
    {
        m_gameManager.GameState.OnValueChanged -= GameStateChanged;
    }

    private void GameStateChanged(EGameState p_state)
    {
        if (p_state == EGameState.GAME_OVER)
        {
            m_group.Show();
        }
        else
        {
            m_group.Hide();
        }
    }

    private void Restart()
    {
        m_gameManager.GameState.Value = EGameState.GAME;
        m_scenesManager.ReloadCurrentScene();
    }

    private void GoToMainMenu()
    {
        m_gameManager.GameState.Value = EGameState.MAIN_MENU;
        m_scenesManager.SwitchCurrentScene(m_mainMenuScene);
    }
}