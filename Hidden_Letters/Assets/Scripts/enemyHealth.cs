using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class enemyHealth : MonoBehaviour
    {
        public int _heath = 10;
        
        // Start is called before the first frame update
        public void update_health(int amount)
        {
            _heath -= amount;
            if (_heath <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
