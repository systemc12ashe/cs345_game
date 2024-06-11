using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventClick : MonoBehaviour
{
    public Camera camera;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray myRay = camera.ScreenPointToRay(mousePosition);

        RaycastHit raycastHit;

        bool doesHit = Physics.Raycast(myRay, out raycastHit);

        if (doesHit) {
            Debug.Log(raycastHit.transform.name);
            
        } else {
            Debug.Log("no hit");
        }
    }

    
}
