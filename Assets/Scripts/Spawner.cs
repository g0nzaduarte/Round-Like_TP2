using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public IEnemyFactory enemyFactory;
    public float spawnInterval = 5f;

    [SerializeField] private GameObject enemyFactoryGameObject;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        enemyFactory.CreateEnemy(transform.position);
    }

    private void Awake()
    {
        enemyFactory = enemyFactoryGameObject.GetComponent<IEnemyFactory>();
    }

}
