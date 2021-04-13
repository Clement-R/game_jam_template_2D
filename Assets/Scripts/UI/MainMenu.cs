using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Cake.Millefeuille;

using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button m_startButton;
    [SerializeField] private Button m_creditsButton;
    [SerializeField] private Transform m_credits;

    [Header("Credits")]
    [SerializeField] private Button m_mainMenuButton;

    [Header("Tween")]
    [SerializeField] private float m_duration;
    [SerializeField] private Ease m_easing;

    [Header("Scene")]
    [SerializeField] private SceneReference m_gameScene;

    private ScenesManager m_sceneManager;
    private Camera m_camera;
    private Tween m_tween;

    private void Start()
    {
        m_sceneManager = Container.Get<ScenesManager>();

        m_startButton.onClick.AddListener(StartGame);
        m_creditsButton.onClick.AddListener(GoToCredits);
        m_mainMenuButton.onClick.AddListener(GoToMainMenu);

        m_camera = Camera.main;
    }

    private void StartGame()
    {
        m_sceneManager.SwitchCurrentScene(m_gameScene);
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