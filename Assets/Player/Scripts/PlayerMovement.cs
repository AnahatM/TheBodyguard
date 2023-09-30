using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer[] flippableSprites;
    
    [Header("Input")]
    [SerializeField] private string horizontalInputAxis = "Horizontal";
    [SerializeField] private string verticalInputAxis = "Vertical";

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    private Rigidbody2D rb;

    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetInput();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void SetInput()
    {
        moveInput.x = Input.GetAxisRaw(horizontalInputAxis);
        moveInput.y = Input.GetAxisRaw(verticalInputAxis);
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + (moveSpeed * Time.fixedDeltaTime * moveInput));
    }

    private void FlipSprite()
    {
        if (moveInput.x > 0)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = false;
        }
        if (moveInput.x < 0)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = true;
        }
    }
}
