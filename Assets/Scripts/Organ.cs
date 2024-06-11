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
    private float interval = 3.0f;
    private float timer;
    public int oxygenCount;
    public GameObject oxygen;
    

    public bool isBacteriaSpawnable = false;
    protected bool hasBacteria = false;

    public GameObject bacteriaObject;

    public float bacteriaSpawnTime = 0;
    public float bacteriaOnset = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        oxygenCount = 0;
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
            if (oxygenCount > 0)
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
            Debug.Log("Yay?");
            if (helperList.Count > 0) {
                Debug.Log(helperList.Peek().gameObject.name);
                if (helperList.Peek().isAvailable) {
                    Debug.Log("Yay!");
                    helperList.Peek().agent.SetDestination(target.position);
                    helperList.Peek().isAvailable = false;
            }
            }
            
        } else {
            isStart = true;
        }
    }

    void CreateOxygen()
    {
        timer += Time.deltaTime;
        if (timer>interval)
        {
            oxygenCount += 1;
            timer = 0;
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
