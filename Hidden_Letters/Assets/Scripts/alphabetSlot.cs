using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mono
{
    public class alphabetSlot : MonoBehaviour
    {
        alphabet al;
        public int i;
        public static alphabetSlot instance;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            al = GameObject.FindObjectOfType<alphabet>();
        }
        private void Update()
        {
            if (this.gameObject.transform.childCount <= 0)
            {
                al.isFull[i] = false;
            }


        }
        public void Equid(GameObject item)
        {
            if (item != null)
            {
                for (int i = 0; i < al.alpabet.Length; i++)
                {
                    if (al.isFull[i] == false)
                    {
                        al.isFull[i] = true;
                        Instantiate(item, al.alpabet[i].transform, false);
                        door.instance.check_password(item.gameObject.name.Substring(0, 1));
                        break;
                    }
                }
            }


        }
        public void DropItem()
        {
            foreach (Transform child in transform)
            {
                slot.instance.Equid(child.gameObject);
                GameObject.Destroy(child.gameObject);
                door.instance.answerUI.enabled = false;
                door.instance.questionUI.enabled = true;
                door.instance.removeChar(child.gameObject.name.Substring(0, 1));
            }
        }
    }
}

