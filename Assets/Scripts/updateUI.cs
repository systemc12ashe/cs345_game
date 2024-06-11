using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class updateUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameEndScreeen;
    public static int scoreValue = 0;
    public static int health;
    public TMP_Text info;

    public Slider Slide;
    // Start is called before the first frame update
    void Start()
    {
        health = 20;
        scoreValue = 0;
        info =GetComponentInChildren<TMP_Text>();
        if(info==null)
            Debug.Log("null reference!!!");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {   
            die();
        }

        if (scoreValue == 8)
        {
            win();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreValue = 8;
        }
        info.text = "\nScore: " + scoreValue.ToString();
        Slide.value = health;

    }

    void win()
    {
        Time.timeScale = 0;
        gameEndScreeen.SetActive(true);
    }

    void die()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}
