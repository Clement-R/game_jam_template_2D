using UnityEngine;

using Cake.Millefeuille;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
public class PlayerConfig : Configuration
{
    public float PlayerJumpHeight;
    public float PlayerHorizontalSpeed;
}