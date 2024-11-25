using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 5f; 
    public int maxEnemies = 10; 

    private float nextSpawnTime;

    private void Update()
    {
        
        if (Time.time >= nextSpawnTime && CountActiveEnemies() < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    private int CountActiveEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}


