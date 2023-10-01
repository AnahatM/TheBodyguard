using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    [Header("Character References")]
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform rightArm;
    [SerializeField] private Transform leftArm;
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private GameObject weaponSprite;

    [Header("Aim Settings")]
    [SerializeField] private float spriteZCompensation = 90;

    private EnemyMovement enemyMovement;
    private PresidentHealth president;

    private void Awake()
    {
        weaponSprite.SetActive(false);
    }

    private void OnEnable()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        president = enemyMovement.president;
        weaponSprite.SetActive(true);
    }

    private void Update()
    {
        AimArm(rightArm, 1);
        AimArm(leftArm, 1);
        AimArm(weaponPivot, 0);
    }

    private void AimArm(Transform arm, int allowCompensation)
    {
        Vector3 difference = president.transform.position - arm.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        arm.rotation = Quaternion.Euler(arm.rotation.x, arm.rotation.y, rotationZ + spriteZCompensation * allowCompensation);
    }
}
