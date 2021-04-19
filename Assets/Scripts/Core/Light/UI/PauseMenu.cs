using UnityEngine;
using UnityEngine.UI;

namespace Example.Light
{
    public class PauseMenu : Menu
    {
        [SerializeField] private Button m_resumeButton;
        [SerializeField] private Button m_mainMenuButton;

        private GameManager m_gameManager;

        void Start()
        {
            m_gameManager = GameManager.Instance;;

            m_resumeButton.onClick.AddListener(Resume);
            m_mainMenuButton.onClick.AddListener(GoToMainMenu);

            m_gameManager.GameState.OnValueChanged += GameStateChanged;
            GameStateChanged(m_gameManager.GameState.Value);

            m_group.Hide();
        }

        private void OnDestroy()
        {
            m_gameManager.GameState.OnValueChanged -= GameStateChanged;
        }

        private void GameStateChanged(EGameState p_state)
        {
            if (p_state == EGameState.PAUSE)
            {
                m_group.Show();
            }
            else
            {
                m_group.Hide();
            }
        }

        private void Resume()
        {
            m_gameManager.GameState.Value = EGameState.GAME;
        }

        private void GoToMainMenu()
        {
            m_gameManager.GameState.Value = EGameState.MAIN_MENU;
        }
    }
}