using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DedeKayma.instance.DedeArttır();
        Destroy(collision.gameObject); // Destroy the enemy
        EnemySpawner.killCount++; // Increase the kill count

        // Update the spawn interval based on the new kill count
        FindObjectOfType<EnemySpawner>().UpdateSpawnInterval();

        // Optionally, you might want to add some visual or sound effect here
        Destroy(gameObject); // Destroy the bullet as well
    }
}
