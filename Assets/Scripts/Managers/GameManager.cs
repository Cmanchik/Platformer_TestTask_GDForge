using System;
using Health;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("GamePlay")]
        [SerializeField] private HealthScript firstPlayerHealth;
        [SerializeField] private HealthScript secondPlayerHealth;

        private void Start()
        {
            firstPlayerHealth.DeathEvent.AddListener(DeathPlayer);
            secondPlayerHealth.DeathEvent.AddListener(DeathPlayer);
        }

        private void DeathPlayer()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Win()
        {
            Debug.Log("Win!");
        }
    }
}
