/*

What's the issue we're trying to solve?

- Have to drag and drop references from scene
- Cross scene ref
- DontDestroyOnLoad objects (could use additive scenes instead, eg:music) player gameobject could be recreated from scene to scene
- Configuration being on gameobjects across the whole project

A use case

- On level loaded, spawn the player at a spawnpoint position, play a sound and send an event for level start
    - SpawnManager
    - SoundSystem
    - GameManager: has a ref to LevelManager which will be recreated on every level loaded, 
    - LevelManager (in scene): knows current level

A solution:

- Have Managers being ScriptableObjects (so it can have fields)
- In a first implementation reference Managers directly in components ([SerialzeField])

*/

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