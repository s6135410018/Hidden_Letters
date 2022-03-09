using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class slot : MonoBehaviour
    {
        private inventory inventory;
        alphabet al;
        public int i;
        public static slot instance;
        private void Awake()
        {
            instance = this;
            al = GameObject.FindObjectOfType<alphabet>();
        }
        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        }
        private void Update()
        {
            if (transform.childCount <= 0)
            {
                inventory.isFull[i] = false;
            }
        }
        public void DropItem()
        {
            if (door.instance.open == true)
            {
                foreach (Transform child in transform)
                {
                    alphabetSlot.instance.Equid(child.gameObject);
                    GameObject.Destroy(child.gameObject);
                }
            }

        }
        public void Equid(GameObject item)
        {
            if (item != null)
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(item, inventory.slots[i].transform, false);
                        break;
                    }
                }
            }

        }
    }
}
