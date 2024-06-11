using System;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class PlateletGameManager : MonoBehaviour
{
    public static PlateletGameManager Instance;

    public int score = 0;
    private int health = 50;
    public Slider slide;

    public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI healthText;

    public GameObject winScreen;
    public GameObject loseScreen;

    private Coroutine healthCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
        StartHealthDecay();
    }

    private void StartHealthDecay()
    {
        healthCoroutine = StartCoroutine(DecayHealth());
    }

    private IEnumerator DecayHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f); // Adjusted as needed for wait time
            ReduceHealth(5); // Reduce health by 5 every X seconds
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();

        if (score >= 5)
        {
            ShowWinScreen();
        }
    }

    public void ReduceHealth(int points)
    {
        health -= points;
        UpdateUI();

        if (health <= 0)
        {
            ShowLoseScreen();
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        slide.value = health;
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    private void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
