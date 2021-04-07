using System.Collections;

using UnityEngine;

using Cake.Genoise;
using Cake.Pooling;

namespace Cake.Behaviour
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField] private bool m_pooled = false;
        [SerializeField] private bool m_destroyOnStart = false;

        private void Start()
        {
            if (m_destroyOnStart)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            Routine.Start(_SelfDestroy());
        }

        protected virtual float GetDuration()
        {
            return 0f;
        }

        private IEnumerator _SelfDestroy()
        {
            yield return new WaitForSeconds(GetDuration());

            if (m_pooled)
            {
                SimplePool.Despawn(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}