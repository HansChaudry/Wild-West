using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyAI enemyPrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private int maxEnemiesNumber;
    [SerializeField] private Player player;
    [SerializeField] private GameObject spawnFX; // Reference to the spawn effect GameObject
    [SerializeField] private AudioClip spawnAudioClip; // Audio clip to play on spawn
    [SerializeField] private float initialSpawnDelay; // Time in seconds to wait before spawning the first enemy

    private List<EnemyAI> spawnedEnemies = new List<EnemyAI>();
    private float timeSinceLastSpawn;
    private bool hasStartedSpawn;

    private void Start()
    {
        timeSinceLastSpawn = spawnInterval;
        hasStartedSpawn = false;
        StartCoroutine(StartSpawnDelay());
    }

    private void Update()
    {
        if (hasStartedSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn > spawnInterval)
            {
                timeSinceLastSpawn = 0f;
                if (spawnedEnemies.Count < maxEnemiesNumber)
                {
                    SpawnEnemy();
                }
            }
        }
    }

    private IEnumerator StartSpawnDelay()
    {
        yield return new WaitForSeconds(initialSpawnDelay);
        hasStartedSpawn = true;
    }

    private void SpawnEnemy()
    {
        // Instantiate the enemy
        EnemyAI enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        // Play spawn effect
        if (spawnFX != null)
        {
            // Calculate spawn position for the effect
            Vector3 spawnFXPosition = enemy.transform.position + new Vector3(0, 1f, 0);
            Instantiate(spawnFX, spawnFXPosition, Quaternion.identity);
        }

        // Play spawn audio clip
        if (spawnAudioClip != null)
        {
            // Add an AudioSource component if not already present
            AudioSource audioSource = enemy.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = enemy.gameObject.AddComponent<AudioSource>();
            }
            // Set the audio clip and play
            audioSource.clip = spawnAudioClip;
            audioSource.Play();
        }

        // Set enemy initialization parameters
        int spawnPointindex = spawnedEnemies.Count % spawnPoints.Length;
        enemy.Init(player, spawnPoints[spawnPointindex]);

        // Add enemy to the list
        spawnedEnemies.Add(enemy);
    }
}
