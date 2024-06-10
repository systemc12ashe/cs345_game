using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Organ : MonoBehaviour
{
    [SerializeField] Transform target;

    public bool isStart = true;
    public int numHelpers;
    public Stack<Helper> helperList;

    public bool isBacteriaSpawnable = false;
    protected bool hasBacteria = false;

    public GameObject bacteriaObject;

    public float bacteriaSpawnTime = 0;
    public float bacteriaOnset = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("organ");
        if(isStart) {
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
