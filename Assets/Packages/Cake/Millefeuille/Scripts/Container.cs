using System;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;

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

        public static async Task<T> GetAsync<T>() where T : Manager
        {
            Manager manager = null;
            while (manager == null)
            {
                manager = ContainerData.Instance.Managers.First(e => e.GetType() == typeof(T));
                await Task.Yield();
            }

            return (T) manager;
        }
    }
}