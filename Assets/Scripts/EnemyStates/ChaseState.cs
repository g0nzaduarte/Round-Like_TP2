using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    public void Enter(Enemy enemy) { Debug.Log("Chase state entered"); }
    public void Execute(Enemy enemy)
    {
        enemy.MoveTowardsPlayer();
        enemy.Shoot();
    }
    public void Exit(Enemy enemy) { Debug.Log("Exiting Chase state"); }
}
