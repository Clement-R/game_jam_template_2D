using UnityEngine;

using Cake.Millefeuille;
using Cake.Opera.Data;

namespace Cake.Opera
{
    public class OneShotSFX : MonoBehaviour
    {
        public SFXEvent SFXEvent;

        private SoundSystem m_soundSystem;

        private void Start()
        {
            m_soundSystem = Container.Get<SoundSystem>();
        }

        [ContextMenu("Preview")]
        private void Preview()
        {
            m_soundSystem.PlaySFX(SFXEvent);
        }
    }
}