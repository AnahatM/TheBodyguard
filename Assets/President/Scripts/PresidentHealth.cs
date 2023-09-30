using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentHealth : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField] private int fullHealth = 1000;

    private InterfaceManager interfaceManager;

    public int health;

    private void Awake()
    {
        interfaceManager = FindObjectOfType<InterfaceManager>();
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
        Debug.Log("Game Over");
        FindObjectOfType<SceneFader>().ReloadScene();
    }
}
