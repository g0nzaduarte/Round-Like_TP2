using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDecorator : MonoBehaviour, IPlayerDecorator
{
    private PlayerHealth playerHealth;
    private int originalDamageReduction = 0;
    public int damageReduction = 2; // Reduce el daño recibido en 2 puntos
    public float duration = 5f;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void Apply()
    {
        if (playerHealth != null)
        {
            originalDamageReduction = damageReduction;
            Debug.Log("Shield applied!");
            Invoke(nameof(Remove), duration);
        }
    }

    public void Remove()
    {
        if (playerHealth != null)
        {
            Debug.Log("Shield removed!");
        }
        Destroy(this);
    }
}

