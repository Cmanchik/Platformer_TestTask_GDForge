using System;
using UnityEngine;

namespace Monument
{
    public class MonumentMoveLogic : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] private Transform endPos;

        [Range(0f, 1f)]
        [Space] [SerializeField] private float speed;
        
        public bool IsUp { get; set; }

        private void FixedUpdate()
        {
            transform.position = Vector2.Lerp(transform.position, IsUp ? endPos.position : startPos.position, speed);
        }
    }
}
