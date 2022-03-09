using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class pickup : MonoBehaviour
    {
        private inventory inventory;
        public GameObject item;
        // Start is called before the first frame update
        void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player"))
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(item, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
        
    }
}
