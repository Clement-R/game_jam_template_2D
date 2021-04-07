using System.Collections.Generic;

using UnityEngine;

using Cake.Millefeuille;
using Cake.Opera.Data;

namespace Cake.Opera
{
    using UnityEngine;

    using Cake.Behaviour;
    using Cake.Pooling;

    [CreateAssetMenu(fileName = "SoundSystem", menuName = "Manager/SoundSystem", order = 0)]
    public class SoundSystem : Manager
    {
        [SerializeField] private Sounds m_sounds;
        [SerializeField] private GameObject m_oneShotSFX;

        public void PlaySFX(string p_eventName)
        {
            SFXSound sfx = m_sounds.Get(p_eventName);
            if (sfx == null)
            {
                Debug.Log($"{p_eventName} wasn't found in registered sounds");
            }

            Play(sfx);
        }

        public void PlaySFX(SFXEvent p_event)
        {
            SFXSound sfx = m_sounds.Get(p_event);
            if (sfx == null)
            {
                Debug.Log($"{p_event} wasn't found in registered sounds");
            }

            Play(sfx);
        }

        private void Play(SFXSound p_sfx)
        {
            var player = SimplePool.Spawn(m_oneShotSFX);

            var audioSource = player.GetComponent<AudioSource>();
            audioSource.clip = p_sfx.GetClip();
            audioSource.volume = p_sfx.GetVolume();
            audioSource.pitch = p_sfx.GetPitch();
            audioSource.Play();

            var autoDestroy = player.GetComponent<SFXAutoDestroy>();
            autoDestroy.Destroy();
        }
    }
}