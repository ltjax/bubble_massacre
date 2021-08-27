using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    List<GameObject> bubbles = new List<GameObject>();

    public GameObject bubblePrefab;
    float MIN_RADIUS = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBubble(transform.localPosition, 2.0f * Vector3.right, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBubble(Vector3 position, Vector3 velocity, float radius)
    {
        var bubble = Instantiate(bubblePrefab, position, Quaternion.identity);
        bubbles.Add(bubble);
        var bubbleScript = bubble.GetComponent<BubbleScript>();
        bubbleScript.velocity = velocity;
        bubbleScript.radius = radius;
    }

    public void HitBubble(GameObject bubble)
    {
        var bubbleScript = bubble.GetComponent<BubbleScript>();

        var childRadius = 0.5f * bubbleScript.radius;
        if (childRadius >= MIN_RADIUS)
        {
            SpawnBubble(bubble.transform.position, bubbleScript.velocity.x * Vector3.left, childRadius);
            SpawnBubble(bubble.transform.position, bubbleScript.velocity.x * Vector3.right, childRadius);
        }

        bubbles.Remove(bubble);
        Destroy(bubble);
    }
}
