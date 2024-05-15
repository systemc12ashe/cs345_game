using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Organ : MonoBehaviour
{
    [SerializeField] Transform target;

    public static bool isStart = false;

    public static int numHelpers;
    

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
        if(isStart) {
            if (Helper.isAvailable) {
                Helper.agent.SetDestination(target.position);
                Helper.isAvailable = false;
            }
        } else {
            isStart = true;

        }
        
        
    }
}
