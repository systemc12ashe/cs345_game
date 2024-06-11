using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Organ : MonoBehaviour
{
    [SerializeField] Transform target;

    public bool isStart = true;
    public int numHelpers;
    public Stack<Helper> helperList;
    public bool oxygenated = false;

    public bool isBacteriaSpawnable = false;
    protected bool hasBacteria = false;

    public GameObject bacteriaObject;

    public float bacteriaSpawnTime = 0;
    public float bacteriaOnset = 0;

    
    private float interval = 3.0f;
    private float oxygenInterval = 4.0f;
    private float oxygenTimer = 2.0f;
    private float timer;
    public GameObject oxygen;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        helperList = new Stack<Helper>();
        Helper[] allHelpers = FindObjectsOfType<Helper>();
        foreach (var helper in allHelpers)
        {
            helperList.Push(helper);
        }
        if(isBacteriaSpawnable){
            InvokeRepeating("SpawnBacteria", bacteriaOnset, bacteriaSpawnTime);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "scene2")
        {
            CreateOxygen();
            if (oxygenated)
            {
                oxygen.SetActive(true);
            }
            else
            {
                oxygen.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bacteriaObject.SetActive(false);
        helperList.Push(other.GetComponent<Helper>());
        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        helperList.Pop();
    }

    void OnMouseDown() {
        if(isStart) {
            if (helperList.Peek().isAvailable) {
                helperList.Peek().agent.SetDestination(target.position);
                helperList.Peek().isAvailable = false;
            }
            
        } else {
            isStart = true;
        }
    }

    void CreateOxygen()
    {
        timer += Time.deltaTime;
        
        if (this.name == "Lungs")
        {
            if (timer > interval)
            {
                oxygenated = true;
                timer = 0;
            }
        }
        else
        {
            if (oxygenated == false)
            {
                if (timer > oxygenInterval)
                {
                    updateUI.health--;
                    timer = 0;
                }
            }
            else
            {
                if (timer > oxygenTimer)
                {
                    oxygenated = false;
                    timer = 0;
                }
            }
            
        }
        
    }

    void SpawnBacteria()
    {
        if (!hasBacteria) {
            hasBacteria = true;
            Debug.Log(gameObject.name);
            //Instantiate(bacteriaInstance, transform.position, transform.rotation);
            bacteriaObject.SetActive(true);
        }
    }
}
