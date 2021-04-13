using System;
using System.Linq;

namespace Cake.Millefeuille
{
    public static class Container
    {
        public static T Get<T>() where T : Manager
        {
            var manager = ContainerData.Instance.Managers.First(e => e.GetType() == typeof(T));
            if (manager == null)
            {
                throw new NullReferenceException($"No manager found of type {typeof(T)}");
            }

            return (T) manager;
        }
    }
}