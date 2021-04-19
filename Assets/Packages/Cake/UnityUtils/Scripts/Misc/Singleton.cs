using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace Cake.Utils
{
    /// <summary>
    /// Monobehaviour based singleton class.
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Returns whether there is no active singleton (TRUE) 
        /// or if one is active and assigned (FALSE)
        /// </summary>
        public static bool IsNull
        {
            get
            {
                return m_instance == null;
            }
        }

        public static T Instance
        {
            get
            {
                if (IsNull)
                {
                    var go = new GameObject($"{typeof(T)} Singleton");
                    m_instance = go.AddComponent<T>();
                }

                return m_instance;
            }
        }

        [SerializeField, Tooltip("If the singleton already exists and is destroyed, " +
            "does it destroy only the component (FALSE) or will it also destroy " +
            "the GameObject the component is attached to (TRUE).")]
        protected bool m_destroyGameObject = true;

        private static T m_instance = null;

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this as T;
                OnAwake();
            }
            else if (m_destroyGameObject)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnDestroy()
        {
            if (m_instance == this)
            {
                m_instance = null;
                OnDestroyed();
            }
        }

        protected virtual void OnAwake()
        {
            // override to implement custom behaviour
        }
        protected virtual void OnDestroyed()
        {
            // override to implement custom behaviour
        }

        public static async Task WaitForInstance()
        {
            while (m_instance == null)
            {
                await Task.Delay(60);
            }
        }
    }
}