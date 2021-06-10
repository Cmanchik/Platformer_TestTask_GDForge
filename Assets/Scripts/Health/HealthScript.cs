using System;
using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class HealthScript : MonoBehaviour
    {
        [SerializeField] private UnityEvent deathEvent;
        [SerializeField] private LayerMask deathLayer;

        private void Start()
        {
            deathEvent.AddListener(Death);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == deathLayer)
            {
                deathEvent.Invoke();
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}
