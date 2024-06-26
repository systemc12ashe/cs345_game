using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuSelections : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mainMenu();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelOne();   
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LevelOne()
    {
        SceneManager.LoadScene(3);
    }
    
    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(1);
    }

    public void pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
    
}