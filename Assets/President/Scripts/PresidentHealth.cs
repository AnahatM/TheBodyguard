using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentHealth : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField] private int fullHealth = 1000;

    private InterfaceManager interfaceManager;
    private PlayerStats playerStats;
    private Pause pause;

    public int health;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        interfaceManager = FindObjectOfType<InterfaceManager>();
        pause = FindObjectOfType<Pause>();
    }

    private void Start()
    {
        health = fullHealth;
    }

    private void Update()
    {
        interfaceManager.SetPresidentHealthBar((float)health / (float)fullHealth);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
            HandleGameOver();
    }

    private void HandleGameOver()
    {
        pause.PauseGame(showUI: false);
        interfaceManager.ShowGameOverUI(playerStats.timeSurvived, playerStats.kills);
    }
}
