using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Gameplay Values")]
    [SerializeField] private int cashDrop = 10;

    [Header("Health Values")]
    [SerializeField] private int fullHealth = 100;

    public int health;

    private void Start()
    {
        health = fullHealth;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
            HandleDeath();
    }

    private void HandleDeath()
    {
        // TODO Death Particle

        // Increase Player Stats
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.cash += cashDrop;
        playerStats.kills++;

        Destroy(gameObject);
    }
}
