using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostDecorator : MonoBehaviour, IPlayerDecorator
{
    private PlayerMovement playerMovement;
    private float originalSpeed;
    public float boostMultiplier = 1.5f;
    public float duration = 5f;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void Apply()
    {
        if (playerMovement != null)
        {
            originalSpeed = playerMovement.speed;
            playerMovement.speed *= boostMultiplier;
            Debug.Log("Speed boost applied!");
            Invoke(nameof(Remove), duration);
        }
    }

    public void Remove()
    {
        if (playerMovement != null)
        {
            playerMovement.speed = originalSpeed;
            Debug.Log("Speed boost removed!");
        }
        Destroy(this);
    }
}


