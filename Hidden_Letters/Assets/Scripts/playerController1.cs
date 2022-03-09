using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace mono
{
    public class playerController1 : MonoBehaviour
    {
        [SerializeField] GameObject Bullet;
        [SerializeField] GameObject p1, p2;
        [SerializeField] bullet b;
        float _rate = 0.25f;
        float _timer = 0.0f;
        bool _fire = false;
        Rigidbody2D _rb;
        Vector2 _movement;
        float _speed = 5f;
        public System.Action<bool> Action_walk;
        public System.Action<float, float> Action_vel;
        public System.Action Action_R, Action_L, Action_B;
        public static float _x;
        public static float _z;
        bool _once = false;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _fire == false)
            {
                Lauch();
                _fire = true;

            }
            if (_fire == true)
            {
                _timer += Time.deltaTime;
                if (_timer > _rate)
                {
                    _fire = false;
                    _once = false;
                    _timer = 0.0f;
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Open_Item();
            }
        }

        private void FixedUpdate()
        {
            Move();
        }
        void Move()
        {
            _x = Input.GetAxisRaw("Horizontal");
            _z = Input.GetAxisRaw("Vertical");
            _rb.velocity = new Vector2(_x * _speed * 50 * Time.deltaTime, _z * _speed * 50 * Time.deltaTime);
            Action_vel?.Invoke(_x, _z);
            if (_x > 0 || _x < 0)
            {
                Action_walk?.Invoke(true);
            }
            else if (_z > 0 || _z < 0)
            {
                Action_walk?.Invoke(true);
            }
            else
            {
                Action_walk?.Invoke(false);
            }
        }


        public void Lauch()
        {
            if (_fire == false)
            {
                {
                    GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
                    for (int i = 0; i < e.Length; i++)
                    {
                        if (e != null && _once == false)
                        {
                            if (transform.position.x < e[i].transform.position.x)
                            {
                                RaycastHit2D hit = Physics2D.Raycast(_rb.position, Vector2.right, 5f, LayerMask.GetMask("Enemy"));
                                if (hit.collider != null)
                                {
                                    Create_bullet(Quaternion.Euler(0f, 0f, 90f), p1.transform.position, Vector2.right);
                                }
                            }
                            if (transform.position.x > e[i].transform.position.x)
                            {
                                RaycastHit2D hit = Physics2D.Raycast(_rb.position, Vector2.left, 5f, LayerMask.GetMask("Enemy"));
                                if (hit.collider != null)
                                {
                                    Create_bullet(Quaternion.Euler(0f, 0f, 90f), p2.transform.position, Vector2.left);
                                }
                            }
                        }

                    }
                }

            }
        }
        void Create_bullet(Quaternion q, Vector2 p, Vector2 t)
        {
            GameObject _bullet = Instantiate(Bullet, p, q);
            if (_bullet != null)
            {
                _once = true;
                if (_once == true)
                {
                    bullet _bulletOut = _bullet.GetComponent<bullet>();
                    _bulletOut.direction(t);
                }

            }

        }
        void Open_Item()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rb.position + Vector2.up * 0.5f, Vector2.up, 0.1f, LayerMask.GetMask("Item"));
            if (hit.collider != null)
            {
                check_what(hit.collider.tag, hit.collider.gameObject);
            }
        }
        
        void check_what(string hit, GameObject collider)
        {
            switch (hit)
            {
                case "Jar":
                    collider.GetComponent<Animator>().SetTrigger("Broke");
                    collider.GetComponent<CircleCollider2D>().enabled = false;
                    collider.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "Chest":
                    collider.GetComponent<Animator>().SetTrigger("Open");
                    collider.GetComponent<BoxCollider2D>().enabled = false;
                    collider.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "item":
                    collider.GetComponent<BoxCollider2D>().enabled = false;
                    collider.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "Flower":
                    collider.GetComponent<BoxCollider2D>().enabled = false;
                    collider.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "Grass":
                    collider.GetComponent<BoxCollider2D>().enabled = false;
                    collider.transform.GetChild(0).gameObject.SetActive(true);
                    break;
            }
        }
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.name == "IronDoor")
            {
                if (other != null)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
