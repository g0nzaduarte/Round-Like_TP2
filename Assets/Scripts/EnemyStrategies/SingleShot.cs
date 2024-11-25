using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : IShotStrategy
{
    public void Shoot(Enemy enemy)
    {
        if (enemy.Player == null) return;

        GameObject bullet = GameObject.Instantiate(enemy.BulletPrefab, enemy.firePoint.position, Quaternion.identity);

        Vector2 direction = (enemy.Player.position - enemy.transform.position).normalized;
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}

