using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Cake.Millefeuille;

public class SetupHandler : MonoBehaviour
{
    [SerializeField] private SceneReference m_setupScene = null;
    [SerializeField] private SceneReference m_mainMenuScene = null;

    private ScenesManager m_sceneManager;

    private void Start()
    {
#if UNITY_EDITOR
        if (SceneManager.GetActiveScene().name != m_setupScene.SceneName)
        {
            return;
        }
#endif

        m_sceneManager = Container.Get<ScenesManager>();

        if (m_mainMenuScene == null)
        {
            Debug.LogError("Main menu scene not found during setup");
            return;
        }

        m_sceneManager.SwitchCurrentScene(m_mainMenuScene);
    }
}