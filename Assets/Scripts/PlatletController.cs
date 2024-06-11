using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour
{
    public float bounceForce = 10f;

    private GameObject targetCut;
    private bool movingToCut = false;
    private CutSpawner cutSpawner;
    private Rigidbody2D rb;

    // Define the spawn area GameObject
    public GameObject spawnArea;

    void Start()
    {
        cutSpawner = FindObjectOfType<CutSpawner>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for boundary constraints
        if (spawnArea != null)
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, spawnArea.transform.position.x - spawnArea.transform.localScale.x / 2, spawnArea.transform.position.x + spawnArea.transform.localScale.x / 2);
            clampedPosition.y = Mathf.Clamp(transform.position.y, spawnArea.transform.position.y - spawnArea.transform.localScale.y / 2, spawnArea.transform.position.y + spawnArea.transform.localScale.y / 2);
            transform.position = clampedPosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("No hit detected.");
            }

            if (hit.collider != null && hit.collider.CompareTag("Cut"))
            {
                targetCut = hit.collider.gameObject;
                movingToCut = true;
            }
        }

        if (movingToCut && targetCut != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetCut.transform.position, 5f * Time.deltaTime);
            Debug.Log("Moving to: " + targetCut.transform.position);

            if (Vector3.Distance(transform.position, targetCut.transform.position) < 0.1f)
            {
                StartCoroutine(FixCut(targetCut));
                movingToCut = false;
            }
        }
    }

    private IEnumerator FixCut(GameObject cut)
    {
        yield return new WaitForSeconds(2f);
        cutSpawner.RemoveCut(cut); // Notify the spawner that the cut has been removed
        Destroy(cut);
        PlateletGameManager.Instance.AddScore(1);
        Debug.Log("Cut fixed and destroyed.");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Calculate direction away from the collision point
            Vector2 awayFromObstacle = rb.position - collision.contacts[0].point;

            // Normalize the direction and apply the bounce force
            rb.AddForce(awayFromObstacle.normalized * bounceForce, ForceMode2D.Impulse);
        }
    }
}
