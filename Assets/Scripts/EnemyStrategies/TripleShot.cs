using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : IShotStrategy
{
    public void Shoot(Enemy enemy)
    {
        if (enemy.Player == null) return;

        float spreadAngle = 15f;

        for (int i = -1; i <= 1; i++)
        {
            
            float angle = spreadAngle * i;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            GameObject bullet = GameObject.Instantiate(enemy.BulletPrefab, enemy.firePoint.position, Quaternion.identity);

            Vector2 direction = rotation * (enemy.Player.position - enemy.transform.position).normalized;
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }
}

