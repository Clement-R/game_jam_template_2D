using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Cake.Genoise;
using Cake.Millefeuille;

namespace Example.Classic
{
    [CreateAssetMenu(fileName = "ScenesManager", menuName = "Manager/ScenesManager", order = 0)]
    public class ScenesManager : Manager
    {

        public SceneReference CurrentScene
        {
            get => m_currentScene;
            private set
            {
                m_currentScene = value;
                SceneManager.SetActiveScene(SceneManager.GetSceneByPath(m_currentScene.ScenePath));
            }
        }

        private SceneReference m_currentScene = null;
        private List<SceneReference> m_loadedScenes = new List<SceneReference>();

        public void SwitchCurrentScene(SceneReference p_scene)
        {
            Routine.Start(_SwitchScenes(p_scene));
        }

        public void LoadScene(SceneReference p_scene)
        {
            if (m_loadedScenes.Contains(p_scene))
            {
                Debug.Log($"Scene [{p_scene.SceneName}] is already loaded, abort LoadScene");
                return;
            }

            SceneManager.LoadSceneAsync(p_scene, LoadSceneMode.Additive);
            m_loadedScenes.Add(p_scene);
        }

        public void UnloadScene(SceneReference p_scene)
        {
            if (!m_loadedScenes.Contains(p_scene))
            {
                Debug.Log($"Scene [{p_scene.SceneName}] is not loaded, abort UnloadScene");
                return;
            }
            SceneManager.UnloadSceneAsync(p_scene.ScenePath);
            m_loadedScenes.Remove(p_scene);
        }

        private IEnumerator _SwitchScenes(SceneReference p_newScene)
        {
            if (m_currentScene != null)
            {
                // unload current one
                var unloadOp = SceneManager.UnloadSceneAsync(m_currentScene.ScenePath);
                yield return unloadOp;

                m_loadedScenes.Remove(CurrentScene);
            }

            // load new one
            var loadOp = SceneManager.LoadSceneAsync(p_newScene, LoadSceneMode.Additive);
            yield return loadOp;

            // Set current scene
            m_loadedScenes.Add(p_newScene);
            CurrentScene = p_newScene;

            // Xplo adventures load code
            // var start = Time.time;
            // m_fader.FadeIn();

            // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(p_sceneName);
            // asyncLoad.allowSceneActivation = false;

            // // Wait until the asynchronous scene fully loads
            // while (Time.time <= start + m_fader.Duration + 0.05f)
            // {
            //     yield return null;
            // }

            // Time.timeScale = 0f;
            // while (asyncLoad.progress < 0.9f)
            // {
            //     yield return null;
            // }

            // asyncLoad.allowSceneActivation = true;

            // yield return new WaitForSecondsRealtime(1.5f);

            // m_fader.FadeOut();

            // Time.timeScale = 1f;
            // yield return new WaitForSecondsRealtime(m_fader.Duration + 0.05f);
        }

        public void ReloadCurrentScene()
        {
            SwitchCurrentScene(m_currentScene);
        }
    }
}