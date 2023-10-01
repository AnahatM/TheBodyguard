using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer[] flippableSprites;

    [Header("Movement")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float distanceToMaintain = 2.0f;

    private PlayerMovement player;
    private Rigidbody2D rb;

    private Vector3 directionToPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
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
        directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();
    }

    private void MoveToPlayer()
    {
        Vector3 targetPosition = player.transform.position - directionToPlayer * distanceToMaintain;
        rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime));
    }

    private void FlipSprite()
    {
        float playerX = player.transform.position.x;
        if (playerX > transform.position.x)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = false;
        }
        else if (playerX < transform.position.x)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = true;
        }
    }
}
