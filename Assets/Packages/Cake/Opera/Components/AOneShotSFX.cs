using UnityEngine;

using Cake.Opera.Data;

namespace Cake.Opera
{
    public abstract class AOneShotSFX : MonoBehaviour
    {
        public SFXEvent SFXEvent;

        private ISoundSystem m_soundSystem;

        private void Start()
        {
            m_soundSystem = GetSoundSystem();
        }

        protected abstract ISoundSystem GetSoundSystem();

        [ContextMenu("Preview")]
        protected void Preview()
        {
            m_soundSystem.PlaySFX(SFXEvent);
        }
    }
}