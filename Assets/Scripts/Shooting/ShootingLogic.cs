using UnityEngine;

namespace Shooting
{
    public class ShootingLogic : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform gunPoint;

        public void Shoot()
        {
            if (!this) return;
            Instantiate(bulletPrefab, gunPoint.position, transform.rotation);
        }
    }
}
