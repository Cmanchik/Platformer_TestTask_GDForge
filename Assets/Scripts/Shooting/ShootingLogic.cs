using UnityEngine;

namespace Shooting
{
    public class ShootingLogic : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform gunPoint;

        public void Shoot()
        {
            Instantiate(bulletPrefab, gunPoint.position, transform.rotation);
        }
    }
}
