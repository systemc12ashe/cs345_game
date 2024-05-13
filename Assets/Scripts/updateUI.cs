using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class updateUI : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameEndScreeen;
    public static int scoreValue = 0;
    public static int health = 8;
    private TMP_Text info;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
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

        if (scoreValue == 10)
        {
            win();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreValue = 10;
        }
        info.text = "Health: " + health.ToString() + "\nScore: " + scoreValue.ToString();
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
