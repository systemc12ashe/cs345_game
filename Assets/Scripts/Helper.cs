using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Helper : MonoBehaviour
{
    [SerializeField] Transform target;
    public NavMeshAgent agent;
    public bool hasOxygen = false;
    public bool isAvailable = true;
    public GameObject oxygenObj;
    private Transform bacteria;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(target.position);

        if (Vector3.Distance(agent.destination, transform.position) <= .01f)
        {
            isAvailable = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("organ"))
        {
            isAvailable = true;
            if (hasOxygen)
            {
                oxygenObj.SetActive(false);
                hasOxygen = false;
                other.GetComponent<Organ>().oxygenCount+=1;
            }
            else
            {
                oxygenObj.SetActive(true);
                hasOxygen = true;
                other.GetComponent<Organ>().oxygenCount-=1;
            }
        }

        // if(other.gameObject.CompareTag("bacteria")) {
        //     Debug.Log("touch bacteria");
        //     other.gameObject.SetActive(false);
        // }
    }

}
