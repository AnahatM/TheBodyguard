using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pauseUI;

    [Header("User Input")]
    [SerializeField] private KeyCode pauseKey = KeyCode.P;
    [SerializeField] private KeyCode pauseKeyAlt = KeyCode.Escape;

    [Header("Pause Values")]
    [SerializeField] private float pauseTimeScale = 0;

    private PresidentHealth presidentHealth;
    private Shop shop;

    private float startTimeScale = 1;

    public bool isPaused = false;

    private void Awake()
    {
        presidentHealth = FindObjectOfType<PresidentHealth>();
        shop = FindObjectOfType<Shop>();
    }

    private void Start()
    {
        startTimeScale = Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey) || Input.GetKeyDown(pauseKeyAlt))
        {
            if (isPaused)
                UnpauseGame();
            else
                PauseGame();
        }
    }

    public void UnpauseGame()
    {
        Time.timeScale = startTimeScale;
        pauseUI.SetActive(false);
        isPaused = false;
    }

    public void PauseGame(bool showUI = true)
    {
        Time.timeScale = pauseTimeScale;
        if (showUI && !shop.shopActive && !presidentHealth.isGameOver)
            pauseUI.SetActive(true);
        isPaused = true;
    }
}
