using UnityEngine;

using Cake.Millefeuille;
using Cake.Utils.Data;

[CreateAssetMenu(fileName = "GameManager", menuName = "Manager/GameManager", order = 0)]
public class GameManager : Manager
{
    public ListenableValue<bool> Pause;
    public ListenableValue<int> Difficulty;
    public ListenableValue<EGameState> GameState;
    public ListenableValue<string> Level;
}