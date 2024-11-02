using UnityEngine;
using System.Collections;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float initialSpawnInterval = 2f;   // Starting spawn interval
    public float minSpawnInterval = 0.5f;     // Minimum allowed spawn interval
    public float intervalDecreaseRate = 0.05f; // Rate at which the interval decreases

    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn the enemy
            SpawnEnemy();

            // Wait for the current spawn interval
            yield return new WaitForSeconds(currentSpawnInterval);

            // Decrease the spawn interval to increase spawn rate
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - intervalDecreaseRate);
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}