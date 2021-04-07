using System.Collections.Generic;

using UnityEngine;

using Cake.Millefeuille;
using Cake.Opera.Data;

namespace Cake.Opera
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "SoundSystem", menuName = "Manager/SoundSystem", order = 0)]
    public class SoundSystem : Manager
    {
        [SerializeField] private Sounds m_sounds;

        public void PlaySFX(SFXEvent p_event)
        {
            SFXSound sfx = m_sounds.Get(p_event);
            if (sfx == null)
            {
                Debug.Log($"{p_event} wasn't found in registered sounds");
            }

            var obj = new GameObject("SFX");
            var audioSource = obj.AddComponent<AudioSource>();

            audioSource.clip = sfx.GetClip();
            audioSource.volume = sfx.GetVolume();
            audioSource.pitch = sfx.GetPitch();

            audioSource.Play();
        }

        public void PlayOneShotSFX()
        {

        }
    }
}