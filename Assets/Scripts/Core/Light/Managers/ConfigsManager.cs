using System;
using System.Collections.Generic;
using System.Linq;

using Cake.Millefeuille;
using Cake.Utils;

namespace Example.Light
{
    public class ConfigsManager : Singleton<ConfigsManager>
    {
        public List<Configuration> Configs = new List<Configuration>();

        public T Get<T>() where T : Configuration
        {
            var configuration = Configs.FirstOrDefault(e => e.GetType() == typeof(T));
            if (configuration == null)
            {
                throw new NullReferenceException($"No configuration found of type {typeof(T)}");
            }

            return (T) configuration;
        }
    }
}