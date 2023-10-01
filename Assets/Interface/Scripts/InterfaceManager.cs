using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    [Header("Weapon UI")]
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI currentBulletsText;
    [SerializeField] private TextMeshProUGUI magazineSizeText;

    [Header("HUD")]
    [SerializeField] private Slider presidentHealthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private string healthSeparator = "/";
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private string killsLabel = "Kills";
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private string cashSymbol = "$";
    [SerializeField] private TextMeshProUGUI durationText;
    [SerializeField] private string durationSeparator = ":";

    [Header("Inventory UI")]
    [SerializeField] private Transform inventoryUIContainer;
    [SerializeField] private GameObject inventoryButtonPrefab;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameOverKillsText;
    [SerializeField] private string gameOverKillsLabel = "Kills: ";
    [SerializeField] private TextMeshProUGUI gameOverTimeSurvivedText;
    [SerializeField] private string gameOverTtimeSurvivedLabel = "Time Survived: ";

    [Header("Shop UI")]
    [SerializeField] private GameObject shopUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void SetBulletsUI(int bullets, int mag)
    {
        currentBulletsText.text = bullets.ToString("0");
        magazineSizeText.text = mag.ToString("0");
    }

    public void SetWeaponUI(WeaponConfig selectedWeapon)
    {
        weaponName.text = selectedWeapon.name;
    }

    public void SetStatsUI(int durationSeconds, int kills, int cash)
    {
        cashText.text = cashSymbol + cash.ToString("0");
        killsText.text = kills.ToString("0") + killsLabel;

        // Split durationSeconds into minutes and seconds
        int minutes = durationSeconds / 60;
        int seconds = durationSeconds % 60;
        durationText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void SetPresidentHealthBar(float value, int health, int fullHealth)
    {
        presidentHealthBar.value = value;
        healthText.text = health.ToString() + healthSeparator + fullHealth.ToString();
    }

    public void ShowGameOverUI(int timeSurvived, int killCount)
    {
        int minutes = timeSurvived / 60;
        int seconds = timeSurvived % 60;

        string timeSurvivedText = minutes.ToString("00") + ":" + seconds.ToString("00");

        gameOverTimeSurvivedText.text = gameOverTtimeSurvivedLabel + timeSurvivedText;
        gameOverKillsText.text = gameOverKillsLabel + killCount.ToString("000");
        gameOverUI.SetActive(true);
    }


    public void ShowShopUI()
    {
        shopUI.SetActive(true);
    }

    public void HideShopUI()
    {
        shopUI.SetActive(false);
    }

    public void CreateInventoryButton(WeaponConfig weapon)
    {
        InventoryButton btn = Instantiate(
            inventoryButtonPrefab,
            inventoryUIContainer
        ).GetComponent<InventoryButton>();
        btn.linkedWeapon = weapon;
        btn.UpdateIcon();
    }
}
