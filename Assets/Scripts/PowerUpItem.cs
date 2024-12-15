using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, Shield }
    public PowerUpType powerUpType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerDecoratorManager>();

            if (player != null)
            {
                switch (powerUpType)
                {
                    case PowerUpType.SpeedBoost:
                        var speedBoost = collision.gameObject.AddComponent<SpeedBoostDecorator>();
                        player.ApplyDecorator(speedBoost);
                        break;

                    case PowerUpType.Shield:
                        var shield = collision.gameObject.AddComponent<ShieldDecorator>();
                        player.ApplyDecorator(shield);
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}

