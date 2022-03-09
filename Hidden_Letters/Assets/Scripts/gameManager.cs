using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace mono
{
    public class gameManager : MonoBehaviour
    {
        [SerializeField] Text time;
        [SerializeField] GameObject panel;
        float timer = 300f;
        private TimeSpan timeplaying;
        public bool timeIsActive = true;
        public static gameManager instance;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            if (time != null)
            {
                timeplaying = TimeSpan.FromSeconds(timer);
                time.text = string.Format("{0:00}:{1:00}:{2:00}", (int)timeplaying.TotalHours, (int)timeplaying.TotalMinutes, (int)timeplaying.Seconds);

            }
        }
        private void Update()
        {
            if (time != null && timeIsActive == true)
            {
                timer -= Time.deltaTime;
                timeplaying = TimeSpan.FromSeconds(timer);
                time.text = string.Format("{0:00}:{1:00}", (int)timeplaying.TotalMinutes, (int)timeplaying.Seconds);
                stopTimer();
            }
            
        }
        public void change_scene()
        {
            scene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void restart()
        {
            scene(SceneManager.GetActiveScene().buildIndex);
        }
        public void mainMenu()
        {
            scene(0);
        }
        void scene(int index)
        {
            SceneManager.LoadScene(index);
        }
        void stopTimer()
        {
            if (timeIsActive == true && timer <= 0)
            {
                timeIsActive = false;
                Time.timeScale = 0;
                panel.SetActive(true);

            }
            else
            {
                timeIsActive = true;
                Time.timeScale = 1;
                panel.SetActive(false);
            }
        }
        public void QuitFromGame()
        {
            Application.Quit();
        }
        }
}
