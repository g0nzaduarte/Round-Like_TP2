using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 2;

    public float lifetime = 3f;
    private float lifeTimer;

    private Vector2 direction;

    private void Start()
    {

    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        lifeTimer += Time.deltaTime;

        if (lifeTimer >= lifetime)
        {
            ReturnToPool();
        }
    }

    private void OnEnable()
    {
        lifeTimer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        lifeTimer = 0f;
        FindObjectOfType<BulletPool>().ReturnBullet(gameObject);
    }

}

