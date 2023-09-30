using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform weaponPivot;

    [Header("Input")]
    [SerializeField] private int shootMouseBtn = 0;


    private PlayerInventory playerInventory;
    private Camera cam;

    public WeaponConfig selectedWeapon;

    private void Awake()
    {
        cam = Camera.main;
        playerInventory = GetComponent<PlayerInventory>();
    }

    private void Start()
    {
        if (playerInventory.inventory[0])
            selectedWeapon = playerInventory.inventory[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(shootMouseBtn))
            ShootSelectedWeapon();
    }

    private void ShootSelectedWeapon()
    {
        GameObject bullet = Instantiate(
            selectedWeapon.bulletPrefab, 
            shootPoint.position, 
            weaponPivot.rotation
        );
    }
}
