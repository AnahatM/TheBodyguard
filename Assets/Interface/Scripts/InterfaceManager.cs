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

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private string killsLabel = "Kills: ";
    [SerializeField] private TextMeshProUGUI timeSurvivedText;
    [SerializeField] private string timeSurvivedLabel = "Time Survived: ";

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

    public void SetPresidentHealthBar(float value)
    {
        presidentHealthBar.value = value;
    }

    public void ShowGameOverUI(int timeSurvived, int killCount)
    {
        timeSurvivedText.text = timeSurvivedLabel + timeSurvived.ToString();
        killsText.text = killsLabel + killsLabel.ToString();
        gameOverUI.SetActive(true);
    }
}
