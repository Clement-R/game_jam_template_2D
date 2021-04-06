using UnityEngine;

namespace Cake.Millefeuille
{
    [CreateAssetMenu(fileName = "PlayerManager", menuName = "Manager/PlayerManager", order = 0)]
    public class PlayerManager : Manager
    {
        public float PlayerJumpHeight;
        public float PlayerHorizontalSpeed;
    }
}