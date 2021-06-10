using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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

        private float _axisHorizontal = 0;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _jumpCurrent = jumpCount;
        }

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="ctx"></param>
        public void MoveRead(InputAction.CallbackContext ctx)
        {
            _axisHorizontal = ctx.ReadValue<float>();
        }

        public void FixedUpdate()
        {
            _rb.velocity = new Vector2(_axisHorizontal * speed, _rb.velocity.y);

            if (_axisHorizontal > 0) transform.rotation = Quaternion.Euler(new Vector2(0, 0));
            else if (_axisHorizontal < 0) transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        }

        /// <summary>
        /// Прыжок
        /// </summary>
        public void Jump(InputAction.CallbackContext ctx)
        {
            if (_jumpCurrent <= 0 || _rb == null || !ctx.performed) return;
            
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
