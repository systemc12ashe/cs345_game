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
        if (timer>interval)
        {
            oxygenCount += 1;
            timer = 0;
        }
    }
}
