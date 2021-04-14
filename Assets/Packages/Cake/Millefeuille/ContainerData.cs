using System.Collections.Generic;

using UnityEngine;

using Cake.Utils;

namespace Cake.Millefeuille
{
    public class ContainerData : Singleton<ContainerData>
    {
        public List<Manager> Managers => m_runtimeManagers;
        [SerializeField] private List<Manager> m_managers;

        private List<Manager> m_runtimeManagers = new List<Manager>();

        protected override void OnAwake()
        {
            foreach (var manager in m_managers)
            {
                var instance = Instantiate(manager);
                var type = instance.GetType().Name;
                instance.name = type;
                m_runtimeManagers.Add(instance);
            }
        }
    }
}