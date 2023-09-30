using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StandardBullet : MonoBehaviour
{
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
}
