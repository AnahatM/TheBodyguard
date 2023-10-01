using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private InterfaceManager interfaceManager;

    public int cash;
    public int kills;
    public int timeSurvived;

    private void Awake()
    {
        interfaceManager = FindObjectOfType<InterfaceManager>();
    }

    private void Start()
    {
        cash = 0;
        kills = 0;
        timeSurvived = 0;
    }

    private void Update()
    {
        interfaceManager.SetStatsUI(timeSurvived, kills, cash);
    }
}
