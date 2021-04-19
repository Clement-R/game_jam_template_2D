using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

using Cake.Millefeuille;

namespace Example.Classic
{
    public class SetupHandler : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private SceneReference m_setupScene = null;
#endif

        private GameManager m_gameManager;

        private async void Start()
        {
#if UNITY_EDITOR
            if (SceneManager.GetActiveScene().name != m_setupScene.SceneName)
            {
                return;
            }
#endif

            var getGameManager = Container.GetAsync<GameManager>();
            await getGameManager;
            m_gameManager = getGameManager.Result;

            await Task.Yield();

            m_gameManager.GameState.Value = EGameState.MAIN_MENU;
        }
    }
}