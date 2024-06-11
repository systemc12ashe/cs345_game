using UnityEngine;
using System.Collections.Generic;

public class CutSpawner : MonoBehaviour
{
    public GameObject cutPrefab; // Assign the Cut Prefab in the Inspector
    public float spawnInterval = 5f;
    public int maxCuts = 5; // Maximum number of cuts that can be present at the same time

    // Reference to the GameObject defining the spawn area
    public GameObject spawnArea;

    private List<GameObject> activeCuts = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnCut", 2f, spawnInterval);
    }

void SpawnCut()
{
    if (activeCuts.Count < maxCuts)
    {
        // Get the bounds of the spawn area
        Bounds bounds = spawnArea.GetComponent<Renderer>().bounds;

        // Define a buffer distance to ensure cuts don't spawn too close to obstacles
        float bufferDistance = 1f;

        // Generate a random position within the spawn area, considering the buffer distance
        Vector3 randomPosition;
        do
        {
            randomPosition = new Vector3(Random.Range(bounds.min.x + bufferDistance, bounds.max.x - bufferDistance),
                                         Random.Range(bounds.min.y + bufferDistance, bounds.max.y - bufferDistance), 0);
        }
        while (IsPositionOnObstacle(randomPosition));

        GameObject newCut = Instantiate(cutPrefab, randomPosition, Quaternion.identity);
        activeCuts.Add(newCut);
    }
}


    private bool IsPositionOnObstacle(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Obstacle"))
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveCut(GameObject cut)
    {
        if (activeCuts.Contains(cut))
        {
            activeCuts.Remove(cut);
        }
    }
}
