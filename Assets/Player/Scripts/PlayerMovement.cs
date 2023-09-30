using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer[] flippableSprites;
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private SpriteRenderer weaponSprite;

    [Header("Input")]
    [SerializeField] private string horizontalInputAxis = "Horizontal";
    [SerializeField] private string verticalInputAxis = "Vertical";

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    private Camera cam;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    private void Awake()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetInput();

        FlipSprite();
        FlipWeapon();
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
        float mouseX = cam.ScreenToWorldPoint(Input.mousePosition).x;
        if (mouseX > transform.position.x)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = false;
        }
        else if (mouseX < transform.position.x)
        {
            foreach (SpriteRenderer sprite in flippableSprites)
                sprite.flipX = true;
        }
    }

    private void FlipWeapon()
    {
        float mouseX = cam.ScreenToWorldPoint(Input.mousePosition).x;
        if (mouseX < transform.position.x)
            weaponSprite.flipY = true;
        else if (mouseX > transform.position.x)
            weaponSprite.flipY = false;
    }
}
