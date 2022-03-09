using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class enemyController : MonoBehaviour
    {
        public System.Action<float, float> Action;
        Rigidbody2D _rb;
        [SerializeField] bool vertical;
        float _speed = 10f;
        float _direction = 1;
        float _timer;
        float _changeTime = 2.0f;
        public static enemyController instance;
        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _timer = _changeTime;
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _direction = -_direction;
                _timer = _changeTime;
            }
        }
        private void FixedUpdate() {
            if (vertical)
            {
                _rb.velocity = new Vector2(0, _speed * 10 * Time.deltaTime * _direction); 
                Action?.Invoke(0, _direction);  
            }
            else
            {
                _rb.velocity = new Vector2(_speed * 10 * Time.deltaTime * _direction, 0); 
                Action?.Invoke(_direction, 0);  
            }
        }
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.collider.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                gameManager.instance.restart();
            }
        }
    }
}
