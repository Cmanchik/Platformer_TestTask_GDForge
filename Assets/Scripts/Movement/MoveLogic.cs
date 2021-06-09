using System;
using System.Linq;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveLogic : MonoBehaviour
    {
        /// <summary>
        /// Скорость перемещение
        /// </summary>
        [Header("Movement")]
        [SerializeField]
        [Tooltip("Скорость перемещение")]
        protected float speed;

        /// <summary>
        /// Сила прыжка
        /// </summary>
        [SerializeField]
        [Tooltip("Сила прыжка")]
        protected float jumpForce;

        [SerializeField]
        private int jumpCount;
        private int _jumpCurrent;
        
        private Rigidbody2D _rb;

        [Space]
        [Header("Ground Check")]

        [SerializeField]
        private Transform jumpPoint;
        [SerializeField]
        private LayerMask[] groundLayer;

        [Space]

        [SerializeField]
        protected float widthCheckGround;
        [SerializeField]
        protected float heightCheckGround;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _jumpCurrent = jumpCount;
        }

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="axisHorizontal">Направление по оси X</param>
        public void Move(float axisHorizontal)
        {
            _rb.velocity = new Vector2(axisHorizontal * speed, _rb.velocity.y);

            if (axisHorizontal > 0) transform.rotation = Quaternion.Euler(new Vector2(0, 0));
            else if (axisHorizontal < 0) transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        }

        /// <summary>
        /// Прыжок
        /// </summary>
        public void Jump()
        {
            if (_jumpCurrent <= 0) return;
            
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _jumpCurrent--;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IsGroundedUpdate();
        }

        /// <summary>
        /// Отслеживание соприкосновения с землей
        /// </summary>
        private void IsGroundedUpdate()
        {
            if (!groundLayer.Any(mask => Physics2D.OverlapBox(jumpPoint.position,
                new Vector3(widthCheckGround, heightCheckGround), 0, mask.value))) return;
            _jumpCurrent = jumpCount;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(jumpPoint.position, new Vector3(widthCheckGround, heightCheckGround));
        }
    }
}
