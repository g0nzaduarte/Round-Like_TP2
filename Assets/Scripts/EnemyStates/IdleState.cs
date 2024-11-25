using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyState
{
    public void Enter(Enemy enemy) { Debug.Log("Idle state entered"); }
    public void Execute(Enemy enemy)
    {
        if (Vector2.Distance(enemy.transform.position, enemy.Player.position) < enemy.chaseRange)
        {
            enemy.ChangeState(new ChaseState());
        }
    }
    public void Exit(Enemy enemy) { Debug.Log("Exiting Idle state"); }
}

