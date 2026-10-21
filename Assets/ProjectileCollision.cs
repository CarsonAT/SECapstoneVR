using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // Ignore hands and socket objects
        if (collision.gameObject.CompareTag("Hand") ||
            collision.gameObject.CompareTag("Socket"))
        {
            return;
        }

        // Spawn the explosion at the orb's position
        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);
    }
}