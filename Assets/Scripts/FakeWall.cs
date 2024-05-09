using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FakeWall : MonoBehaviour
{
    private NavMeshObstacle navMeshObstacle;
    private Renderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        navMeshObstacle = GetComponent<NavMeshObstacle>();
        spriteRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("mouse down");
        navMeshObstacle.enabled = !navMeshObstacle.enabled;

        Color customColor = new Color(0.3333333f, 0.1098039f, 0.08627451f, 1);
        spriteRenderer.material.SetColor("_Color", customColor);
    }
}
