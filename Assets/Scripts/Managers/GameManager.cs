using System;
using Health;
using Shooting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("GamePlay")]
        [SerializeField] private HealthScript firstPlayerHealth;
        [SerializeField] private HealthScript secondPlayerHealth;

        [Header("Reset")] 
        [SerializeField] private Transform startPosFirstPlayer;
        [SerializeField] private Transform startPosSecondPlayer;
        
        [Space] 
        
        [SerializeField] private GameObject totem;

        private void Awake()
        {
            Time.timeScale = 0;
        }

        private void Start()
        {
            firstPlayerHealth.DeathEvent.AddListener(Lose);
            secondPlayerHealth.DeathEvent.AddListener(Lose);
        }

        private void Lose()
        {
            Time.timeScale = 0;
            UIManager.Instance.OpenLosePanel();
        }

        public void Win()
        {
            Time.timeScale = 0;
            UIManager.Instance.OpenMainMenu();
        }

        public void EndGame()
        {
            Application.Quit();
        }

        public void ResumeNormalTime()
        {
            Time.timeScale = 1;
        }

        public void ResetWorld()
        {
            BulletScript[] bullets = FindObjectsOfType<BulletScript>();
            foreach (BulletScript bullet in bullets)
            {
                Destroy(bullet.gameObject);
            }

            if (!totem.activeInHierarchy) totem.SetActive(true);

            firstPlayerHealth.transform.position = startPosFirstPlayer.position;
            secondPlayerHealth.transform.position = startPosSecondPlayer.position;
        }
    }
}
