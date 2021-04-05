using UnityEngine;

using UnityEditor;
using UnityEditor.SceneManagement;

/// <summary>
/// Scene auto loader.
/// </summary>
/// <description>
/// This class adds a File > Scene Autoload menu containing options to select
/// a "Main scene" enable it to be auto-loaded when the user presses play
/// in the editor. When enabled, the selected scene will be loaded on play,
/// then the original scene will be reloaded on stop.
///
/// Based on an idea on this thread:
/// http://forum.unity3d.com/threads/157502-Executing-first-scene-in-build-settings-when-pressing-play-button-in-editor
/// </description>

namespace Cake.Utils
{
    [InitializeOnLoad]
    static class SceneAutoLoader
    {
        // Static constructor binds a playmode-changed callback.
        // [InitializeOnLoad] above makes sure this gets executed.
        static SceneAutoLoader()
        {
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        // Menu items to select the "Main" scene and control whether or not to load it.
        [MenuItem("File/Scene Autoload/Select Main Scene...")]
        private static void SelectMainScene()
        {
            string mainScene = EditorUtility.OpenFilePanel("Select Main Scene", Application.dataPath, "unity");
            mainScene = mainScene.Replace(Application.dataPath, "Assets"); //project relative instead of absolute path
            if (!string.IsNullOrEmpty(mainScene))
            {
                MainScene = mainScene;
                LoadMainOnPlay = true;
            }
        }

        [MenuItem("File/Scene Autoload/Load Main On Play", true)]
        private static bool ShowLoadMainOnPlay()
        {
            return !LoadMainOnPlay;
        }

        [MenuItem("File/Scene Autoload/Load Main On Play")]
        private static void EnableLoadMainOnPlay()
        {
            LoadMainOnPlay = true;
        }

        [MenuItem("File/Scene Autoload/Don't Load Main On Play", true)]
        private static bool ShowDontLoadMainOnPlay()
        {
            return LoadMainOnPlay;
        }

        [MenuItem("File/Scene Autoload/Don't Load Main On Play")]
        private static void DisableLoadMainOnPlay()
        {
            LoadMainOnPlay = false;
        }

        // Play mode change callback handles the scene load/reload.
        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (!LoadMainOnPlay)
            {
                return;
            }

            if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                // User pressed play -- autoload Main scene.
                PreviousScene = EditorSceneManager.GetActiveScene().path;
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    try
                    {
                        EditorSceneManager.OpenScene(MainScene, OpenSceneMode.Additive);
                    }
                    catch
                    {
                        Debug.LogError(string.Format("error: scene not found: {0}", MainScene));
                        EditorApplication.isPlaying = false;

                    }
                }
                else
                {
                    // User cancelled the save operation -- cancel play as well.
                    EditorApplication.isPlaying = false;
                }
            }

            // isPlaying check required because cannot OpenScene while playing
            if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
            {
                // User pressed stop -- reload previous scene.
                try
                {
                    EditorSceneManager.OpenScene(PreviousScene);
                }
                catch
                {
                    Debug.LogError(string.Format("error: scene not found: {0}", PreviousScene));
                }
            }
        }

        // Properties are remembered as editor preferences.
        private const string cEditorPrefLoadMainOnPlay = "SceneAutoLoader.LoadMainOnPlay";
        private const string cEditorPrefMainScene = "SceneAutoLoader.MainScene";
        private const string cEditorPrefPreviousScene = "SceneAutoLoader.PreviousScene";

        private static bool LoadMainOnPlay
        {
            get
            {
                return EditorPrefs.GetBool(cEditorPrefLoadMainOnPlay, false);
            }
            set
            {
                EditorPrefs.SetBool(cEditorPrefLoadMainOnPlay, value);
            }
        }

        private static string MainScene
        {
            get
            {
                return EditorPrefs.GetString(cEditorPrefMainScene, "Main.unity");
            }
            set
            {
                EditorPrefs.SetString(cEditorPrefMainScene, value);
            }
        }

        private static string PreviousScene
        {
            get
            {
                return EditorPrefs.GetString(cEditorPrefPreviousScene, EditorSceneManager.GetActiveScene().path);
            }
            set
            {
                EditorPrefs.SetString(cEditorPrefPreviousScene, value);
            }
        }
    }
}