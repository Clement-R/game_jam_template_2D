using System;
using System.Collections;

using UnityEngine;

using Cake.Millefeuille;

namespace Example.Classic
{
    public class PlayerControler : PausableMonoBehaviour
    {
        private PlayerManager m_playerManager = null;
        private PlayerConfig m_playerConfig = null;

        private Rigidbody2D m_rb;
        private Vector2 m_input;

        protected async void Awake()
        {
            await Container.WaitReady();

            m_rb = GetComponent<Rigidbody2D>();

            m_playerManager = Container.Get<PlayerManager>();
            m_playerConfig = Container.GetConfig<PlayerConfig>();

            m_playerManager.Player = gameObject;
        }

        protected override void PauseChanged(bool p_pause)
        {
            m_rb.simulated = !p_pause;
        }

        protected override void Update()
        {
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

            if (m_rb == null)
                return;

            float horizontalVelocity = 0f;

            if (m_input.x != 0)
            {
                horizontalVelocity = m_playerConfig.PlayerHorizontalSpeed * m_input.x;
            }

            if (m_input.y != 0)
            {
                m_rb.AddForce(Vector2.up * m_playerConfig.PlayerJumpHeight, ForceMode2D.Impulse);
            }

            m_rb.velocity = new Vector2(horizontalVelocity, m_rb.velocity.y);

            m_input = Vector2.zero;
        }

        public void Bump()
        {
            m_rb.velocity = m_rb.velocity.SetY(0f);
            m_rb.AddForce(Vector2.up * m_playerConfig.PlayerJumpHeight, ForceMode2D.Impulse);
        }
    }
}