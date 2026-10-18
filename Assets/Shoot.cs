using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Shoot Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 3f;

    public void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Assign the bullet prefab and fire point!");
            return;
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }

    public void SetBulletPrefab(GameObject newPrefab)
    {
        if (newPrefab != null)
        {
            bulletPrefab = newPrefab;
        }
    }
}