using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialShot : IShotStrategy
{
    public void Shoot(Enemy enemy)
    {

        int numberOfBullets = 5;
        float angleStep = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
          
            float angle = angleStep * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            
            GameObject bullet = GameObject.Instantiate(enemy.BulletPrefab, enemy.firePoint.position, Quaternion.identity);

            
            Vector2 direction = rotation * Vector2.up;
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }
}

