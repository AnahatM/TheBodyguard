using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer[] flippableSprites;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float distanceToMaintain = 3f;

    private PresidentHealth president;
    private Rigidbody2D rb;

    private Vector3 directionToPresident;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        president = FindObjectOfType<PresidentHealth>();
    }

    private void Update()
    {
        SetDirection();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void SetDirection()
    {
        directionToPresident = president.transform.position - transform.position;
        directionToPresident.Normalize();
    }

    private void MoveToPlayer()
    {
        Vector3 targetPosition = president.transform.position - directionToPresident * distanceToMaintain;
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime));
    }

    private void FlipSprite()
    {
        float presidentX = president.transform.position.x;
        if (presidentX > transform.position.x)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = false;
        }
        else if (presidentX < transform.position.x)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = true;
        }
    }
}
