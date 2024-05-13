using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Organ : MonoBehaviour
{
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown() {
        Debug.Log("organ");
        if (Helper.isAvailable) {
            Helper.agent.SetDestination(target.position);
            Helper.isAvailable = false;
        }
        
    }
}
