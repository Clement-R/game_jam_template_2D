using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

using Cake.Genoise;
using Cake.Millefeuille;

public class GameStateSceneSwitcher : MonoBehaviour
{
    [SerializeField] private SceneReference m_mainMenuScene;

    private GameManager m_gameManager;
    private ScenesManager m_scenesManager;

    private async void Start()
    {
        var getGameManager = Container.GetAsync<GameManager>();
        var getSceneManager = Container.GetAsync<ScenesManager>();

        await Task.WhenAll(getGameManager, getSceneManager);

        m_gameManager = getGameManager.Result;
        m_scenesManager = getSceneManager.Result;

        m_gameManager.GameState.OnValueChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(EGameState p_state)
    {
        Debug.Log($"State switched to {p_state}");
        if (p_state == EGameState.MAIN_MENU)
        {
            m_scenesManager.SwitchCurrentScene(m_mainMenuScene);
        }
    }
}