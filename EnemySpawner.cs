using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public float spawnDelay;
    private float spawnCooldown;
    public int maxEnemies;
    public int currentNumberOfEnemies;

    void Start()
    {
        
    }

    void Update()
    {
        if (spawnCooldown <= 0 && currentNumberOfEnemies < maxEnemies)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[0], spawnPoints[randSpawnPoint].position, transform.rotation);
            currentNumberOfEnemies += 1;
            spawnCooldown = spawnDelay;
        }
        else
        {
            spawnCooldown -= Time.deltaTime;
        }
    }

    public void EnemyCounterUpdate()
    {
        currentNumberOfEnemies--;
    }
}
