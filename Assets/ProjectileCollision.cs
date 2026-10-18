using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionLifetime = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 impactPosition = transform.position;

        Destroy(gameObject);

        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                impactPosition,
                Quaternion.identity
            );

            Destroy(explosion, explosionLifetime);
        }
    }
}