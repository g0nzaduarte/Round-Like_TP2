using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject CreateEnemy(Vector2 position)
    {
        return Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}

