using UnityEngine;



public class EnemySpawner : MonoBehaviour

{

    public GameObject enemyPrefab; // The enemy prefab

    public float spawnInterval = 2f; // Time between spawns

    public Transform[] spawnPoints; // Array of spawn points

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

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

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