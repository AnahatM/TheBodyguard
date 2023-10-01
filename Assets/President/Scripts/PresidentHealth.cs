using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentHealth : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField] public int fullHealth = 1500;

    private InterfaceManager interfaceManager;
    private PlayerStats playerStats;
    private Pause pause;

    public int health;

    public bool isGameOver = false;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        interfaceManager = FindObjectOfType<InterfaceManager>();
        pause = FindObjectOfType<Pause>();
    }

    private void Start()
    {
        isGameOver = false;
        health = fullHealth;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, fullHealth);
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
        isGameOver = true;
        pause.PauseGame(showUI: false);
        interfaceManager.ShowGameOverUI(playerStats.timeSurvived, playerStats.kills);
    }
}
