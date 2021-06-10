using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Health
{
    public class HealthScript : MonoBehaviour
    {
        [SerializeField] private UnityEvent deathEvent;
        public UnityEvent DeathEvent => deathEvent;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("DeathObject"))
            {
                deathEvent.Invoke();
            }
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}
