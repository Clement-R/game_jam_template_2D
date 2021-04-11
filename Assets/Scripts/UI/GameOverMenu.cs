using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button m_restartButton;
    [SerializeField] private Button m_mainMenuButton;

    void Start()
    {
        m_restartButton.onClick.AddListener(Restart);
        m_mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void Restart()
    {

    }

    private void GoToMainMenu()
    {

    }
}