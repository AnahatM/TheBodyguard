using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Keybindings")]
    [SerializeField] private KeyCode shopKey = KeyCode.S;

    private Pause pause;
    private InterfaceManager interfaceManager;

    public bool shopActive = false;

    private void Awake()
    {
        pause = FindObjectOfType<Pause>();
        interfaceManager = FindObjectOfType<InterfaceManager>();
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
        if (shopActive) return;
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
}
