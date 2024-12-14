using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private IEnemyFactory enemyFactory;

    [SerializeField] private GameObject enemyFactoryGameObject;

    public void SpawnEnemy(Vector2 position)
    {
        if (enemyFactory != null)
        {
            enemyFactory.CreateEnemy(position);
        }
        else
        {
            Debug.LogError("No enemy factory has been assigned.");
        }
    }

    private void Awake()
    {
        enemyFactory = enemyFactoryGameObject.GetComponent<IEnemyFactory>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        SpawnEnemy (transform.position);
    }

}
