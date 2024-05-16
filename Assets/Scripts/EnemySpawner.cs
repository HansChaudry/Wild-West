using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    private List<Transform> availableSpawnPoints = new List<Transform>();
    public float spawnInterval = 5f;
    private float lastSpawnTime;

    void Start()
    {
        // Initialize the available spawn points list with all spawn points
        availableSpawnPoints.AddRange(spawnPoints);
        lastSpawnTime = Time.time;
    }

    void Update()
    {
        // Check if there are available spawn points and if enough time has passed since the last spawn
        if (availableSpawnPoints.Count > 0 && Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnEnemy()
    {
        // Choose a random available spawn point
        int randomIndex = Random.Range(0, availableSpawnPoints.Count);
        Transform spawnPoint = availableSpawnPoints[randomIndex];

        // Spawn the enemy at the chosen spawn point
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Remove the chosen spawn point from the available list
        availableSpawnPoints.RemoveAt(randomIndex);
    }
}
