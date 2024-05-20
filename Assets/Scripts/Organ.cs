using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Organ : MonoBehaviour
{
    [SerializeField] Transform target;

    public static bool isStart = false;

    public static int numHelpers;

    public GameObject bacteriaInstance;

    protected bool hasBacteria = false;

    public float bacteriaSpawnTime;
    public float bacteriaOnset;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnBacteria", bacteriaOnset, bacteriaSpawnTime);


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

    // Update is called once per frame
    void Update()
    {
        // if (gameObject.CompareTag("organ")) {

        // }
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
