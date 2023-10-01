using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private InterfaceManager interfaceManager;
    private PresidentHealth president;

    public int cash;
    public int kills;
    public int timeSurvived;

    private float startTime;
    private bool isCountingTime = true;

    private void Awake()
    {
        interfaceManager = FindObjectOfType<InterfaceManager>();
        president = FindObjectOfType<PresidentHealth>();
    }

    private void Start()
    {
        cash = 0;
        kills = 0;
        startTime = Time.time;
    }

    private void Update()
    {
        if (isCountingTime && !president.isGameOver)
        {
            timeSurvived = (int)(Time.time - startTime);
        }

        interfaceManager.SetStatsUI(timeSurvived, kills, cash);
    }
}
