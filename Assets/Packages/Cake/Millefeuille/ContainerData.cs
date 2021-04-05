using System.Collections.Generic;

using UnityEngine;

using Cake.Utils;

namespace Cake.Millefeuille
{
    public class ContainerData : Singleton<ContainerData>
    {
        public List<Manager> Managers => m_managers;
        [SerializeField] private List<Manager> m_managers;
    }
}