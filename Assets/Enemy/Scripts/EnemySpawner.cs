using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Values")]
    [SerializeField] private float initialSpawnDelay = 4.0f; 
    [SerializeField] private float minSpawnDelay = 1.0f;
    [SerializeField] private float spawnDelayDecrease = 0.1f;
    [SerializeField] private EnemyMovement[] enemyPrefabs;
    [SerializeField] private Transform[] spawnSpots;
    [SerializeField] public bool canSpawn = true;

    private PresidentHealth president;

    private float currentNextSpawnDelay; 

    private void Awake()
    {
        president = FindObjectOfType<PresidentHealth>();
    }

    private void Start()
    {
        currentNextSpawnDelay = initialSpawnDelay;
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        transform.position = president.transform.position;
    }

    private IEnumerator Spawner()
    {
        while (canSpawn)
        {
            WaitForSeconds wait = new(currentNextSpawnDelay);
            yield return wait;

            SpawnEnemy();

            currentNextSpawnDelay -= spawnDelayDecrease;
            currentNextSpawnDelay = Mathf.Clamp(currentNextSpawnDelay, minSpawnDelay, initialSpawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        // Choose Random Enemy Type to Spawn
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)].gameObject;

        // Choose Random Spawn Spot to Spawn
        Transform enemySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];

        EnemyMovement spawnedEnemy = Instantiate(
            enemyToSpawn,
            enemySpawnSpot.position,
            Quaternion.identity
        ).GetComponent<EnemyMovement>();
        spawnedEnemy.president = president;
    }
}
