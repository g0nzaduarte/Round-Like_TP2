using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class SpeedCommand : ICommand
{
    private PlayerMovement player;
    private float originalSpeed;
    private float multiplier;

    public SpeedCommand(PlayerMovement player, float multiplier)
    {
        this.player = player;
        this.multiplier = multiplier;
        this.originalSpeed = player.speed;
    }

    public void Execute()
    {
        player.speed *= multiplier;
        Debug.Log("Player speed increased!");
    }

    public void Undo()
    {
        player.speed = originalSpeed;
        Debug.Log("Player speed reset!");
    }
}

public class NukeCommand : ICommand
{
    public void Execute()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
        Debug.Log("All enemies destroyed!");
    }

    public void Undo()
    {
        Debug.Log("Cannot undo this command.");
    }
}

