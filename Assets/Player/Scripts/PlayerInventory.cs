using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Start Inventory")]
    [SerializeField] private List<WeaponConfig> startInventory;

    public List<WeaponConfig> inventory;

    private void Start()
    {
        inventory = startInventory;
    }
}
