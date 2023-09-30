using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StandardBullet : MonoBehaviour
{
    [Header("Gameplay Values")]
    [SerializeField] private int bulletDamage = 10;

    [Header("Bullet Movement")]
    [SerializeField] private float bulletSpeed = 15;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetBulletSpeed();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void SetBulletSpeed()
    {
        Vector2 moveDirection = transform.right;
        rb.velocity = moveDirection.normalized * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(bulletDamage);
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.TryGetComponent<PresidentHealth>(out var presidentHealth))
        {
            presidentHealth.TakeDamage(bulletDamage);
            Destroy(gameObject);
            return;
        }
    }
}
