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

    [Header("References")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI btnText;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Colors")]
    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;

    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
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
}
