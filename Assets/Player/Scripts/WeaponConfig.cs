using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Weapon Config")]
public class WeaponConfig : ScriptableObject
{
    [Header("Weapon Info")]
    [SerializeField] public Sprite weaponSprite;
    [SerializeField] public string weaponName = "Weapon Name";

    [Header("Shooting Info")]
    [SerializeField] public int magazineSize = 30;
    [SerializeField] public int fireRate = 60;
    [SerializeField] public float reloadTime = 1.5f;

    [Header("Bullets")]
    [SerializeField] public GameObject bulletPrefab;

    [Header("Audio")]
    [SerializeField] public AudioClip shootSFX;
    [SerializeField] public AudioClip reloadSFX;
    [SerializeField] public AudioClip emptyClipSFX;

    [Header("Particles")]
    [SerializeField] public ParticleSystem shootParticles;
}