using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Organ : MonoBehaviour
{
    [SerializeField] Transform target;
    public GameObject bacteriaInstance;
    protected bool hasBacteria = false;

    public float bacteriaSpawnTime;
    public float bacteriaOnset;
    public bool isStart = true;
    public int numHelpers;
    public Stack<Helper> helperList;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBacteria", bacteriaOnset, bacteriaSpawnTime);
        helperList = new Stack<Helper>();
        Helper[] allHelpers = FindObjectsOfType<Helper>();
        foreach (var helper in allHelpers)
        {
            helperList.Push(helper);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameObject.CompareTag("organ")) {

        // }
    }
    
    void SpawnBacteria()
    {
        if (!hasBacteria) {
            hasBacteria = true;
            Debug.Log(gameObject.name);
            Instantiate(bacteriaInstance, transform.position, transform.rotation);
            gameObject.tag = "organInfected";
            }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            if (helperList.Peek().isAvailable) {
                Debug.Log("Yay!");
                helperList.Peek().agent.SetDestination(target.position);
                helperList.Peek().isAvailable = false;
            }
        } else {
            isStart = true;

        }
        
        
    }
}
