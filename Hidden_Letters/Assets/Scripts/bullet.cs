using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace mono
{
    public class bullet : MonoBehaviour
    {
        public System.Action action;
        Rigidbody2D _rb;
        float _speed = 20f;
        public List<GameObject> enemies;
        public static bullet instance;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            enemies = new List<GameObject>();
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.magnitude > 500.0f)
            {
                Destroy(gameObject);
            }

        }

        public void direction(Vector2 t)
        {
            if (t != null)
            {
                _rb.velocity = t * _speed;
            }

        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (other.gameObject != null)
                {
                    action?.Invoke();
                    Destroy(gameObject);
                    enemies.Add(other.gameObject);
                }
                Check_Enemy();

            }

        }

        void Check_Enemy()
        {
            if (enemies.Count > 0)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    GameObject currentEnemy = enemies[i];
                    enemyHealth enemyHealth = currentEnemy.GetComponent<enemyHealth>();
                    enemyHealth.update_health(5);
                }
                enemies.Clear();
            }
        }
    }
}
