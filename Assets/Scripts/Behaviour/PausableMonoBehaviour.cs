using UnityEngine;

using Cake.Millefeuille;

namespace Cake.Core
{
    public abstract class PausableMonoBehaviour : MonoBehaviour
    {
        protected GameManager m_gameManager = null;

        protected virtual void Start()
        {
            m_gameManager = Container.Get<GameManager>();
            m_gameManager.Pause.OnValueChanged += PauseChanged;
        }

        protected virtual void OnDestroy()
        {
            m_gameManager.Pause.OnValueChanged -= PauseChanged;
        }

        protected abstract void PauseChanged(bool p_pause);

        protected virtual void Update()
        {
            if (m_gameManager.Pause.Value)
                return;
        }

        protected virtual void FixedUpdate()
        {
            if (m_gameManager.Pause.Value)
                return;
        }
    }
}