using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform weaponPivot;

    [Header("Shooting Values")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float initialShootingDelay = 1.5f;
    [SerializeField] private float shootDelay = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Shoot), initialShootingDelay, shootDelay);
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(Shoot));
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            shootPoint.position,
            weaponPivot.rotation
        );
    }
}
