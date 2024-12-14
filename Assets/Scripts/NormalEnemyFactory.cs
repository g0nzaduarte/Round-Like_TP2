using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyFactory : MonoBehaviour, IEnemyFactory
{
    public GameObject enemyPrefab;

    public Enemy CreateEnemy(Vector2 position)
    {
        return Instantiate(enemyPrefab, position, Quaternion.identity).GetComponent<Enemy>();
    }
}

