using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button m_resumeButton;
    [SerializeField] private Button m_mainMenuButton;

    void Start()
    {
        m_resumeButton.onClick.AddListener(Resume);
        m_mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void Resume()
    {

    }

    private void GoToMainMenu()
    {

    }
}