using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private TextMeshProUGUI currentBulletsText;
    [SerializeField] private TextMeshProUGUI magazineSizeText;
    [SerializeField] private Slider presidentHealthBar;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private string killsLabel = "Kills";
    [SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private string cashSymbol = "$";
    [SerializeField] private TextMeshProUGUI durationText;
    [SerializeField] private string durationSeparator = ":";

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
        durationText.text = durationSeconds.ToString("0") + durationSeparator; // TODO split into minutes : seconds
    }

    public void SetPresidentHealthBar(float value)
    {
        presidentHealthBar.value = value;
    }

    public void ShowGameOverUI(int timeSurvived, int killCount)
    {
        gameOverTimeSurvivedText.text = gameOverTtimeSurvivedLabel + timeSurvived.ToString();
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
}
