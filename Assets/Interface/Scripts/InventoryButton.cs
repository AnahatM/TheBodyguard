using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image inventoryBtnIcon;

    private PlayerWeapon playerWeapon;

    public WeaponConfig linkedWeapon;

    // TODO "active" indicator if selected

    private void Awake()
    {
        playerWeapon = FindObjectOfType<PlayerWeapon>();
    }

    public void UpdateIcon()
    {
        inventoryBtnIcon.sprite = linkedWeapon.weaponSprite;
    }

    public void HandleClick()
    {
        playerWeapon.SelectWeapon(linkedWeapon);
    }
}
