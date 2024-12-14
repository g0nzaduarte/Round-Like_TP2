using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemySharedData sharedData; // Asignar este objeto en el inspector

    public Transform Player;
    public Transform firePoint; 
    public GameObject BulletPrefab; 

    public float fireRate = 1f; 
    private float nextFireTime = 0f;

    private float changeStrategyInterval = 5f;
    private float nextStrategyChangeTime = 0f;

    public StateMachine<Enemy> StateMachine { get; private set; }

    private void Start()
    {

        Debug.Log($"Enemy Speed: {sharedData.moveSpeed}, Chase Range: {sharedData.chaseRange}");

        StateMachine = new StateMachine<Enemy>(this);
        StateMachine.ChangeState(new IdleState());

        SetShotStrategy(new SingleShot());
    }

    private void Update()
    {
        StateMachine.Update();

        
        if (Time.time >= nextStrategyChangeTime)
        {
            nextStrategyChangeTime = Time.time + changeStrategyInterval; 
            ChangeShotStrategy();
        }
    }


    private void ChangeShotStrategy()
    {
        
        int randomStrategy = Random.Range(0, 3);

        switch (randomStrategy)
        {
            case 0:
                SetShotStrategy(new SingleShot());
                Debug.Log("Enemy changed to SingleShot.");
                break;
            case 1:
                SetShotStrategy(new TripleShot());
                Debug.Log("Enemy changed to TripleShot.");
                break;
            case 2:
                SetShotStrategy(new RadialShot());
                Debug.Log("Enemy changed to RadialShot.");
                break;
        }
    }

    public void MoveTowardsPlayer()
    {
        if (Player == null) return;

        Vector2 direction = (Player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, Player.position, sharedData.moveSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            if (shotStrategy != null)
            {
                shotStrategy.Shoot(this);
            }
            else
            {
                Debug.LogWarning("Shot strategy is null.");
            }
        }
    }

    public IShotStrategy shotStrategy;

    public void SetShotStrategy(IShotStrategy strategy)
    {
        shotStrategy = strategy;
    }

}

