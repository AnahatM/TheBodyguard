using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerWeapon : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private Transform spawnedBulletsContainer;

    [Header("KeyBindings")]
    [SerializeField] private KeyCode reloadKey = KeyCode.R;

    [Header("Input")]
    [SerializeField] private int shootMouseBtn = 0;

    private int currentBulletCount = 0;
    private int currentMagSize = 0;
    private float timeSinceLastShot = 0f;

    private bool isReloading = false;

    private Camera cam;
    private PlayerInventory playerInventory;
    private InterfaceManager interfaceManager;

    public WeaponConfig selectedWeapon;

    private void Awake()
    {
        cam = Camera.main;
        playerInventory = GetComponent<PlayerInventory>();
        interfaceManager = FindObjectOfType<InterfaceManager>();
    }

    private void Start()
    {
        if (playerInventory.inventory[0])
            SelectWeapon(playerInventory.inventory[0]);
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(shootMouseBtn) && !isReloading && timeSinceLastShot >= 1f / selectedWeapon.fireRate)
        {
             ShootSelectedWeapon();
        }

        if (Input.GetKeyDown(reloadKey) && !isReloading && currentBulletCount < currentMagSize)
        {
             StartCoroutine(ReloadWeapon());
        }

        interfaceManager.SetBulletsUI(currentBulletCount, currentMagSize);
        interfaceManager.SetWeaponUI(selectedWeapon);
    }

    private void SelectWeapon(WeaponConfig weapon)
    {
        selectedWeapon = weapon;
        currentMagSize = selectedWeapon.magazineSize;
        currentBulletCount = selectedWeapon.magazineSize;
    }

    private void ShootSelectedWeapon()
    {
        if (currentBulletCount <= 0)
        {
            Debug.Log("Need to Reload");
            return;
        }

        GameObject bullet = Instantiate(
            selectedWeapon.bulletPrefab,
            shootPoint.position,
            weaponPivot.rotation,
            spawnedBulletsContainer
        );

        currentBulletCount--;
        currentBulletCount = Mathf.Clamp(currentBulletCount, 0, currentMagSize);

        timeSinceLastShot = 0f; 
    }

    private IEnumerator ReloadWeapon()
    {
        isReloading = true;

        yield return new WaitForSeconds(selectedWeapon.reloadTime);

        currentBulletCount = currentMagSize;
        isReloading = false;
    }
}
