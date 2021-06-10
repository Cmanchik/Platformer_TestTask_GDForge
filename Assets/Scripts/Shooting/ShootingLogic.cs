using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooting
{
    public class ShootingLogic : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform gunPoint;

        public void Shoot(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed) return;
            Instantiate(bulletPrefab, gunPoint.position, transform.rotation);
        }
    }
}
