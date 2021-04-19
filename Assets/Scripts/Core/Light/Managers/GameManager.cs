using UnityEngine.SceneManagement;

using Cake.Utils;
using Cake.Utils.Data;

namespace Example.Light
{
    public class GameManager : Singleton<GameManager>
    {
        public ListenableValue<bool> Pause;
        public ListenableValue<int> Difficulty;
        public ListenableValue<EGameState> GameState;
        public ListenableValue<string> Level;

        public void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().path);
        }
    }
}