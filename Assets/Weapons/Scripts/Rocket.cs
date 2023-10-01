using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : StandardBullet
{
    [Header("References")]
    [SerializeField] private GameObject blastRadius;
    [SerializeField] private GameObject explosionParticles;

    [Header("Rocket Settings")]
    [SerializeField] private float objectDestroyDelay = 1f;

    protected override void Start()
    {
        base.Start();
        blastRadius.SetActive(false);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out var enemyHealth))
        {
            enemyHealth.TakeDamage(base.bulletDamage);
            DestroyRocket();
            return;
        }

        if (collision.gameObject.TryGetComponent<PresidentHealth>(out var presidentHealth))
        {
            presidentHealth.TakeDamage(base.bulletDamage);
            DestroyRocket();
            return;
        }
    }

    private void DestroyRocket()
    {
        // Activate Blast Radius
        blastRadius.SetActive(true);

        // Instantiate Explosion Particles
        Instantiate(
            explosionParticles,
            transform.position,
            Quaternion.identity
        );

        Destroy(gameObject, objectDestroyDelay);
    }
}
