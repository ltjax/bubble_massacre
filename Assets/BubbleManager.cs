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
        SpawnBubble(transform.position, 2.0f * Vector3.right, 1.0f);
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

    public void SplitBubble(GameObject bubble)
    {
        var bubbleScript = bubble.GetComponent<BubbleScript>();

        var childRadius = 0.5f * bubbleScript.radius;
        if (childRadius < MIN_RADIUS)
        {
            return;
        }

        SpawnBubble(bubble.transform.position, bubbleScript.velocity.x * Vector3.left, childRadius);
        SpawnBubble(bubble.transform.position, bubbleScript.velocity.x * Vector3.right, childRadius);

        /*var left = Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
        var leftChild = left.GetComponent<BubbleScript>();
        bubbles.Add(left);

        var right = Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
        var rightChild = right.GetComponent<BubbleScript>();
        bubbles.Add(right);

        leftChild.velocity = new Vector3(-bubbleScript.velocity.x, 0, 0);
        leftChild.radius = childRadius;

        rightChild.velocity = new Vector3(bubbleScript.velocity.x, 0, 0);
        rightChild.radius = childRadius;*/

        bubbles.Remove(bubble);
        Destroy(bubble);
    }
}
