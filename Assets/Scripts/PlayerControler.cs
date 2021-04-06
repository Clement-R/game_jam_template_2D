using System;

using UnityEngine;

using Cake.Core;

namespace Cake.Millefeuille
{

    public class PlayerControler : PausableMonoBehaviour
    {
        private PlayerManager m_playerManager = null;

        private Rigidbody2D m_rb;
        private Vector2 m_input;

        protected override void Start()
        {
            base.Start();

            m_rb = GetComponent<Rigidbody2D>();
            m_playerManager = Container.Get<PlayerManager>();
        }

        protected override void PauseChanged(bool p_pause)
        {
            if (p_pause)
            {
                m_rb.simulated = false;
            }
            else
            {
                m_rb.simulated = true;
            }
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_gameManager.Pause.Value = !m_gameManager.Pause.Value;
            }

            base.Update();

            if (Input.GetKeyDown(KeyCode.W))
            {
                m_input.Set(m_input.x, 1f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                m_input.Set(-1f, m_input.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                m_input.Set(1f, m_input.y);
            }
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            float horizontalVelocity = 0f;

            if (m_input.x != 0)
            {
                horizontalVelocity = m_playerManager.PlayerHorizontalSpeed * m_input.x;
            }

            if (m_input.y != 0)
            {
                m_rb.AddForce(Vector2.up * m_playerManager.PlayerJumpHeight, ForceMode2D.Impulse);
            }

            m_rb.velocity = new Vector2(horizontalVelocity, m_rb.velocity.y);

            m_input = Vector2.zero;
        }
    }
}