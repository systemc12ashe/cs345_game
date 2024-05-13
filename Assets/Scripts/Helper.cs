using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Helper : MonoBehaviour
{
    [SerializeField] Transform target;
    public static NavMeshAgent agent;

    public static bool isAvailable = true;
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collide");
        if(other.gameObject.CompareTag("organ")) {
            isAvailable = true;
            Debug.Log("enter");
            //gameObject.SetActive(false);
            // Organ.numHelpers += 1;
            // Debug.Log(Organ.numHelpers);
        }
    }
}
