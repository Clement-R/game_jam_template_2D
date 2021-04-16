using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Cake.Funfetti
{
    public class Screenshake : MonoBehaviour
    {
        [SerializeField, Range(2, 3)] private int m_pow = 3;
        [SerializeField] private float m_recoverySpeed = 1.5f;

        [SerializeField] private bool m_translation = true;
        [SerializeField] private Vector2 m_maxOffset = new Vector2(25f, 25f);

        [SerializeField] private bool m_rotation = true;
        [SerializeField] private float m_maxAngle = 45f;

        private float m_trauma = 0f;
        private float m_shake = 0f;
        private int m_seed;

        private Vector3 m_basePosition = Vector3.zero;
        private float m_baseRotation = float.MinValue;

        private void Start()
        {
            m_seed = Random.Range(0, 1000);
        }

        private void LateUpdate()
        {
            if (m_trauma == 0f)
            {
                m_basePosition = transform.position;
                m_baseRotation = transform.rotation.eulerAngles.z;

                return;
            }

            if (m_shake > 0f)
            {
                Shake();
            }

            // Reduce trauma over time
            AddTrauma(-m_recoverySpeed * Time.deltaTime);
        }

        public void AddTrauma(float p_amount)
        {
            m_trauma = Mathf.Clamp01(m_trauma + p_amount);
            m_shake = Mathf.Pow(m_trauma, m_pow);
        }

        private void Shake()
        {
            var seed = m_seed * Time.deltaTime;

            if (m_translation)
            {
                Vector2 offset = new Vector2(
                    m_maxOffset.x * m_shake * Noise(1, seed),
                    m_maxOffset.y * m_shake * Noise(2, seed)
                );

                transform.position = m_basePosition + (Vector3) offset;
            }

            if (m_rotation)
            {
                float angle = m_maxAngle * m_shake * Noise(0, seed);
                transform.rotation = Quaternion.Euler(0f, 0f, m_baseRotation + angle);
            }
        }

        /// <summary>
        /// Return a value based on perlin noise between -1 and 1
        /// </summary>
        /// <param name="p_x">x coord</param>
        /// <param name="p_y">y coord</param>
        /// <returns>float value between -1 and 1</returns>
        private float Noise(float p_x, float p_y)
        {
            return (Mathf.PerlinNoise(p_x, p_y) - 0.5f) * 2f;
        }
    }
}