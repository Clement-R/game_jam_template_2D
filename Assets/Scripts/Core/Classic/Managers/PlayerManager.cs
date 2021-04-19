using UnityEngine;

using Cake.Millefeuille;

namespace Example.Classic
{
    [CreateAssetMenu(fileName = "PlayerManager", menuName = "Manager/PlayerManager", order = 0)]
    public class PlayerManager : Manager
    {
        public GameObject Player;
    }
}