using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class bulletPartical : MonoBehaviour
    {
        [SerializeField] GameObject Fire;
        [SerializeField] bullet bullet;
        // Start is called before the first frame update
        private void OnEnable()
        {
            bullet.action += Fire_ball;
        }
        private void OnDisable()
        {
            bullet.action -= Fire_ball;

        }
        void Fire_ball()
        {
            GameObject ball = Instantiate(Fire, bullet.transform.position, bullet.transform.rotation);
            Destroy(ball, 0.1f);
        }
        
    }
}
