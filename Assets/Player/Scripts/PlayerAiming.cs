using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [Header("Custom Cursor")]
    [SerializeField] private Texture2D customCursor;

    [Header("Character References")]
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform rightArm;
    [SerializeField] private Transform leftArm;
    [SerializeField] private Transform weaponPivot;

    [Header("Aim Settings")]
    [SerializeField] private float spriteZCompensation = 90;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        AimArm(rightArm, 1);
        AimArm(leftArm, 1);
        AimArm(weaponPivot, 0);
    }

    private void AimArm(Transform arm, int allowCompensation)
    {
        Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - arm.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        arm.rotation = Quaternion.Euler(arm.rotation.x, arm.rotation.y, rotationZ + spriteZCompensation * allowCompensation);
    }
}
