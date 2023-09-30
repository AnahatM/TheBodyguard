using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [Header("Character References")]
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform rightArm;
    [SerializeField] private Transform leftArm;
    [SerializeField] private Transform weaponPivot;

    [Header("Character References")]
    [SerializeField] private float spriteZCompensation = 90;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        AimArm(rightArm, 1);
        AimArm(leftArm, 1);
        AimArm(weaponPivot, 0);
    }

    private void AimArm(Transform arm, byte compensation)
    {
        Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - arm.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        arm.rotation = Quaternion.Euler(arm.rotation.x, arm.rotation.y, rotationZ + spriteZCompensation * compensation);
    }
}
