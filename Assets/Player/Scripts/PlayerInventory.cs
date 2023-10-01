using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private List<WeaponConfig> startInventory;

    private InterfaceManager interfaceManager;
    private PlayerWeapon playerWeapon;

    public List<WeaponConfig> inventory;

    private void Awake()
    {
        interfaceManager = FindObjectOfType<InterfaceManager>();
        playerWeapon = FindObjectOfType<PlayerWeapon>();
    }

    private void Start()
    {
        foreach (WeaponConfig config in startInventory)
            AddToInventory(config);

        playerWeapon.SelectWeapon(inventory[0]);
    }

    public void AddToInventory(WeaponConfig weapon)
    {
        inventory.Add(weapon);
        interfaceManager.CreateInventoryButton(weapon);
    }
}
