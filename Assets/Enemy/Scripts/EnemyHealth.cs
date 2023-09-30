using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
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
        // TODO Increase killCount and cash
        Destroy(gameObject);
    }
}
