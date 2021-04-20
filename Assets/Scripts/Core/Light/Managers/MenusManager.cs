using UnityEngine;
using UnityEngine.SceneManagement;

using Cake.Utils;
using Cake.Utils.Data;

namespace Example.Light
{
    public class MenusManager : Singleton<MenusManager>
    {
        private GameManager m_gameManager;

        void Start()
        {
            m_gameManager = GameManager.Instance;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                m_gameManager.GameState.Value = EGameState.PAUSE;
                m_gameManager.Pause.Value = !m_gameManager.Pause.Value;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                m_gameManager.GameState.Value = EGameState.GAME_OVER;
            }
        }
    }
}