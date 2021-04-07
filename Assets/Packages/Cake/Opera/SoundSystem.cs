using System.Collections.Generic;

using UnityEngine;

using Cake.Opera.Data;

namespace Cake.Opera
{
    public class SoundSystem
    {
        [SerializeField] private Sounds m_sounds;

        public void PlaySFX(string p_event)
        {
            SFX sfx = m_sounds.Get(p_event);
            if (sfx == null)
            {
                Debug.Log($"{p_event} wasn't found in registered sounds");
            }
        }
    }
}