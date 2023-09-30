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
}
