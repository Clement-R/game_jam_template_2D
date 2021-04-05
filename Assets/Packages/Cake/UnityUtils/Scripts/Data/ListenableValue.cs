using System;

using UnityEngine;

namespace Cake.Utils.Data
{
    [System.Serializable]
    public class ListenableValue<T>
    {
        public Action<T> OnValueChanged;

        public T Value
        {
            get => m_value;

            set
            {
                m_value = value;
                OnValueChanged?.Invoke(m_value);
            }
        }

        [SerializeField] private T m_value;
    }
}