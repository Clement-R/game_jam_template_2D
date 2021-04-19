using UnityEngine;

using Cake.Behaviour;
using Cake.Millefeuille;
using Cake.Opera.Data;
using Cake.Pooling;

namespace Example.Classic
{
    [CreateAssetMenu(fileName = "SoundSystem", menuName = "Manager/SoundSystem", order = 0)]
    public class SoundsManager : Manager, ISoundSystem
    {
        [SerializeField] private Sounds m_sounds;
        [SerializeField] private GameObject m_oneShotSFX;

        private SoundSystem m_soundSystem;

        public void Awake()
        {
            m_soundSystem = new SoundSystem(m_sounds, m_oneShotSFX);
        }

        public void PlaySFX(string p_eventName)
        {
            m_soundSystem.PlaySFX(p_eventName);
        }

        public void PlaySFX(SFXEvent p_event)
        {
            m_soundSystem.PlaySFX(p_event);
        }

        public void Play(SFXSound p_sfx)
        {
            m_soundSystem.Play(p_sfx);
        }
    }
}