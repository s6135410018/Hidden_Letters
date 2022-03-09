using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace mono
{
    public class door : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] public Text answerUI;
        [SerializeField] private string Q;
        [SerializeField] public Text questionUI;
        alphabet al;
        [SerializeField] private string password;
        public string word;
        public bool open = false;

        public static door instance;
        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            al = GameObject.FindObjectOfType<alphabet>();
            questionUI.text = Q;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Open();

            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Open();
            }
        }

        public void check_password(string c)
        {
            if (word.Length < password.Length)
            {
                answerUI.enabled = false;
                questionUI.enabled = true;
                for (int i = 0; i < password.Length; i++)
                {
                    if (c == password[i].ToString())
                    {
                        word += c;
                        break;
                    }
                    else if (c != password[i].ToString())
                    {
                        word += c;
                        break;
                    }

                }
                
            }

            if (word.Length == password.Length)
            {
                if (word == password)
                {
                    answerUI.enabled = true;    
                    questionUI.enabled = false;
                    answerUI.text = "Correct!";
                    answerUI.GetComponent<Text>().color = new Color(0, 255, 255, 255);
                    StartCoroutine(wait());
                }
                else if (word != password)
                {
                    answerUI.enabled = true;
                    questionUI.enabled = false;
                    word = "";
                    answerUI.text = "Wrong. Try Again";
                    answerUI.GetComponent<Text>().color = new Color(255, 0, 0, 255);
                }
            }

        }

        public void removeChar(string c)
        {
            word = word.Replace(c, "");
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(1f);
            gameManager.instance.change_scene();
        }
        public void Open()
        {
            if (!open)
            {
                open = true;
                panel.SetActive(true);               
            }
            else
            {
                open = false;
                panel.SetActive(false);
            }
        }
    
    }
}





