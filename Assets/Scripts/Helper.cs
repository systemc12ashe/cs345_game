using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Helper : MonoBehaviour
{
    [SerializeField] Transform target;
    public NavMeshAgent agent;
    private Transform bacteria;
    public bool isAvailable = true;
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
        Debug.Log("collide");
        if(other.gameObject.CompareTag("organ") || other.gameObject.CompareTag("organInfected")) {
            
            Debug.Log("enter");
            isAvailable = true;
            // Organ.numHelpers += 1;
            // Debug.Log(Organ.numHelpers);
        }
        if(other.gameObject.CompareTag("bacteria")) {
                Debug.Log("touch bacteria");
                Destroy(other.gameObject);

            }
    }

}
