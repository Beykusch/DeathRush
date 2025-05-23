using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab
    public float spawnInterval = 2f; // Initial time between spawns
    public float minSpawnInterval = 0.5f; // Minimum time between spawns
    public float intervalDecreaseAmount = 0.2f; // Amount to decrease the interval
    public int killThreshold = 10; // Number of kills needed to decrease the interval
    public Transform[] spawnPoints; // Array of spawn points
    public float speedIncreaseAmount = 0.5f; // Amount to increase enemy speed
    public static int killCount = 0; // Kill count

    private void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return; // No spawn points available

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the enemy prefab at the spawn point
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Increase enemy speed if applicable
        EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
        if (enemyMover != null)
        {
            // Calculate new speed based on kill count and threshold
            float newSpeed = (killCount / killThreshold) * speedIncreaseAmount;
            EnemyMover.enemySpeed += newSpeed;
            Debug.Log($"Spawned enemy with speed: {EnemyMover.enemySpeed}");
        }
    }

    public void UpdateSpawnInterval()
    {
        // Check if the kill count has reached a multiple of the threshold
        if (killCount > 0 && killCount % killThreshold == 0)
        {
            // Decrease the spawn interval
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseAmount);

            Debug.Log($"Current spawn interval: {spawnInterval}");
            Debug.Log($"Updated kill count: {killCount}");

            // Restart the spawn invocation with the new interval
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw spawn points in the scene view
        Gizmos.color = Color.red;
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                Gizmos.DrawSphere(spawnPoint.position, 0.5f);
            }
        }
    }
}
