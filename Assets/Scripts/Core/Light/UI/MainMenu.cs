using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

namespace Example.Light
{
    public class MainMenu : Menu
    {
        [SerializeField] private Button m_startButton;
        [SerializeField] private Button m_creditsButton;
        [SerializeField] private Transform m_credits;

        [Header("Credits")]
        [SerializeField] private Button m_mainMenuButton;

        [Header("Tween")]
        [SerializeField] private float m_duration;
        [SerializeField] private Ease m_easing;

        private GameManager m_gameManager;
        private Camera m_camera;
        private Tween m_tween;

        private void Start()
        {
            m_startButton.onClick.AddListener(StartGame);
            m_creditsButton.onClick.AddListener(GoToCredits);
            m_mainMenuButton.onClick.AddListener(GoToMainMenu);

            m_camera = Camera.main;

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
            if (p_state == EGameState.MAIN_MENU)
            {
                m_group.Show();
            }
            else
            {
                m_group.Hide();
            }
        }

        private void StartGame()
        {
            m_gameManager.GameState.Value = EGameState.GAME;
        }

        private void GoToCredits()
        {
            if (m_tween != null && m_tween.IsPlaying())
                return;

            m_tween = m_camera.transform.DOMoveX(m_credits.position.x, m_duration, true).SetEase(m_easing);
        }

        private void GoToMainMenu()
        {
            if (m_tween != null && m_tween.IsPlaying())
                return;

            m_tween = m_camera.transform.DOMoveX(0f, m_duration, true).SetEase(m_easing);
        }
    }
}