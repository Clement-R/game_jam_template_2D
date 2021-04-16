using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Cake.Millefeuille;

[CreateAssetMenu(fileName = "ConfigsManager", menuName = "Manager/ConfigsManager", order = 0)]
public class ConfigsManager : Manager
{
    public List<Configuration> Configs;

    public T Get<T>() where T : Configuration
    {
        var configuration = Configs.First(e => e.GetType() == typeof(T));
        if (configuration == null)
        {
            throw new NullReferenceException($"No configuration found of type {typeof(T)}");
        }

        return (T) configuration;
    }
}