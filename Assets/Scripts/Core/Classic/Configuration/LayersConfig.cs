using UnityEngine;

using Cake.Millefeuille;

namespace Example.Classic
{
    [CreateAssetMenu(fileName = "LayersConfig", menuName = "Configs/LayersConfig", order = 0)]
    public class LayersConfig : Configuration
    {
        public LayerMask Player;
        public LayerMask Ground;
        public LayerMask Enemy;
        public LayerMask Obstacle;
        public LayerMask Destructible;
    }
}