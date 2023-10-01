using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WeaponBuyButton : MonoBehaviour
{
    [Header("Shop Values")]
    [SerializeField] public WeaponConfig purchasableWeapon;
    [SerializeField] private int weaponCost = 100;
    [SerializeField] private string currencySymbol = "$";

    [Header("UI Settings")]
    [SerializeField] private float btnDestroyDelay = 1f;

    [Header("References")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI btnText;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Colors")]
    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;

    private PlayerStats playerStats;
    private PlayerInventory playerInventory ;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
            UpdateUI();
    }

    private void UpdateUI()
    {
        icon.sprite = purchasableWeapon.weaponSprite;
        btnText.text = purchasableWeapon.weaponName;
        priceText.text = currencySymbol + weaponCost;
        priceText.color = playerStats.cash >= weaponCost ? positiveColor : negativeColor;
    }

    public void HandleClick()
    {
        if (playerStats.cash < weaponCost) return;
        playerInventory.AddToInventory(purchasableWeapon);
        playerStats.cash -= weaponCost;
        Destroy(gameObject, btnDestroyDelay);
    }
}
