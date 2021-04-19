using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Cake.Millefeuille;

namespace Example.Classic
{
    public class PlayerCrushBehaviour : MonoBehaviour
    {
        private PlayerControler m_playerControler;
        private LayersConfig m_layersConfig;
        private Rigidbody2D m_rb;
        private BoxCollider2D m_collider;

        void Start()
        {
            m_rb = GetComponent<Rigidbody2D>();
            m_collider = GetComponent<BoxCollider2D>();

            m_playerControler = GetComponent<PlayerControler>();
            m_layersConfig = Container.GetConfig<LayersConfig>();
        }

        void Update()
        {
            //TODO: if player falling and raycast down detect an enemy
            if (m_rb.velocity.y >= 0f)
                return;

            // var hits = Physics2D.RaycastAll(transform.position, Vector2.down, 5f, m_layersConfig.Enemy.value);
            // Debug.DrawLine(transform.position, transform.position + (Vector3) (Vector2.down * 5f), Color.magenta);

            var hits = Physics2D.BoxCastAll(transform.position, new Vector2(m_collider.size.x, 1f), 0f, Vector2.down, 5f, m_layersConfig.Enemy.value);

            foreach (var hit in hits)
            {
                // kill enemy -> call on death
                Destroy(hit.collider.gameObject);
            }

            if (hits.Length > 0)
            {
                // make player jump a little
                m_playerControler.Bump();
            }
        }
    }
}