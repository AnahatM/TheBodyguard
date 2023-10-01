using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Upgrades")]
    [SerializeField] private int upgradeCost = 50;

    [Header("Keybindings")]
    [SerializeField] private KeyCode shopKey = KeyCode.S;

    private PlayerStats playerStats;

    private Pause pause;
    private InterfaceManager interfaceManager;
    private PresidentHealth presidentHealth;
    private FollowPlayer presidentMovement;

    public bool shopActive = false;

    private void Awake()
    {
        pause = FindObjectOfType<Pause>();
        interfaceManager = FindObjectOfType<InterfaceManager>();
        presidentHealth = FindObjectOfType<PresidentHealth>();
        playerStats = FindObjectOfType<PlayerStats>();
        presidentMovement = presidentHealth.GetComponent<FollowPlayer>();
    }

    private void Start()
    {
        HideShop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(shopKey))
            ToggleShop();
    }

    private void ToggleShop()
    {
        if (shopActive)
            HideShop();
        else
            ShowShop();
    }

    private void ShowShop()
    {
        if (shopActive || presidentHealth.isGameOver || (pause.isPaused && !shopActive)) return;
        shopActive = true;
        pause.PauseGame(showUI: false);
        interfaceManager.ShowShopUI();
    }

    public void HideShop()
    {
        shopActive = false;
        pause.UnpauseGame();
        interfaceManager.HideShopUI();
    }

    public void HealPresidentHealth(int amount)
    {
        if (playerStats.cash < upgradeCost) return;
        presidentHealth.health += amount;
        playerStats.cash -= upgradeCost;
    }

    public void IncreasePresidentMaxHealth(int amount)
    {
        if (playerStats.cash < upgradeCost) return;
        presidentHealth.fullHealth += amount;
        playerStats.cash -= upgradeCost;
    }

    public void IncreasePresidentSpeed(float speedIncrease)
    {
        if (playerStats.cash < upgradeCost) return;
        presidentMovement.moveSpeed += speedIncrease;
        playerStats.cash -= upgradeCost;
    }
}
