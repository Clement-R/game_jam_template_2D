using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Cake.Funfetti
{
    [RequireComponent(typeof(Screenshake))]
    public class ScreenshakeTester : MonoBehaviour
    {
        [Range(0f, 1f)]
        public float Stress;

        private Screenshake m_screenshake;

        private void Start()
        {
            m_screenshake = GetComponent<Screenshake>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InduceStress();
            }
        }

        [ContextMenu("Stress")]
        private void InduceStress()
        {
            m_screenshake.AddTrauma(Stress);
        }
    }
}