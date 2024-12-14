using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Enemy>
{
    public void Enter(Enemy enemy)
    {
        Debug.Log("Idle state entered.");
    }

    public void Execute(Enemy enemy)
    {
        // Referencia al chaseRange desde sharedData
        if (Vector2.Distance(enemy.transform.position, enemy.Player.position) < enemy.sharedData.chaseRange)
        {
            enemy.StateMachine.ChangeState(new ChaseState());
        }
    }

    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Idle state.");
    }
}

