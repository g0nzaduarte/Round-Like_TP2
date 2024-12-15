using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemySharedData sharedData;

    public Transform Player;
    public Transform firePoint; 
    public GameObject BulletPrefab;

    public enum ShotType { Shoot }
    public ShotType currentShotType;

    public float fireRate = 1f;
    private float nextFireTime = 0f;
    private float timer = 0f;

    private float changeStrategyInterval = 5f;
    //private float nextStrategyChangeTime = 0f;

    public StateMachine<Enemy> StateMachine { get; private set; }

    private BulletPool bulletPool;

    private void Start()
    {

        Debug.Log($"Enemy Speed: {sharedData.moveSpeed}, Chase Range: {sharedData.chaseRange}");

        StateMachine = new StateMachine<Enemy>(this);
        StateMachine.ChangeState(new IdleState());

        SetShotStrategy(new SingleShot());

        bulletPool = FindObjectOfType<BulletPool>();

    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            //nextStrategyChangeTime = Time.time + changeStrategyInterval; 
            timer = changeStrategyInterval;
            ChangeShotStrategy();
        }
        StateMachine.Update();
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
            GameObject bullet = bulletPool.GetBullet();
            if (bullet != null)
            {
                bullet.transform.position = firePoint.position;
                bullet.GetComponent<Bullet>().SetDirection((Player.position - transform.position).normalized);

                if (shotStrategy != null)
                {
                    shotStrategy.Shoot(this);
                }

                switch (currentShotType)
                {
                    case ShotType.Shoot:
                        ServiceLocator.AudioService.PlaySound("GunShot1");
                        break;
                        
                }
            }
        }
    }

    public IShotStrategy shotStrategy;

    public void SetShotStrategy(IShotStrategy strategy)
    {
        shotStrategy = strategy;
    }

}

