using System;
using UnityEngine;

namespace Shooting
{
    public class BulletScript : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = transform.rotation.y == 0 ? 
                new Vector2(speed, _rb.velocity.y) : new Vector2(-speed, _rb.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}
