using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public GameObject bubblePrefab;

    public Vector3 velocity = new Vector3(0.02f, 0.0f, 0.0f);
    public float radius = 1.0f;

    float MIN_RADIUS = 0.2f;

    private LevelScript level;
    private Transform sphere;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level").GetComponent<LevelScript>();

        sphere = transform.Find("Sphere");
        sphere.localScale = new Vector3(2 * radius, 2 * radius, 2 * radius);
    }

    // Update is called once per frame
    void Update()
    {
        velocity += level.gravity * Time.deltaTime;
        advance();

        if (level.DoesCollideWithBorder(transform.position, radius, out var normal))
        {
            velocity = Reflect(velocity, new Vector3(normal.x, normal.y, 0));
            advance();
        }

        // to simulate what would happen when hit by rope
        if (Input.GetButtonDown("Fire2"))
        {
            collisionWithRope();
        }
    }

    void advance()
    {
        transform.localPosition = transform.localPosition + velocity * Time.deltaTime;
    }

    Vector3 Reflect(Vector3 velocity, Vector3 normal)
    {
        return velocity - 2 * Vector3.Dot(velocity, normal) * normal;
    }

    public void OnTriggerEnter(Collider other)
    {
        sphere.localScale = new Vector3(radius, radius, radius);

        if (other.CompareTag("Rope"))
        {
            collisionWithRope();
        }
    }

    void collisionWithRope()
    {
        split();
        Destroy(transform.gameObject);
    }

    void split()
    {
        var childRadius = 0.5f * radius;
        if (childRadius < MIN_RADIUS)
        {
            return;
        }

        var left = Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
        var leftChild = left.GetComponent<BubbleScript>();

        var right = Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
        var rightChild = right.GetComponent<BubbleScript>();

        leftChild.velocity = new Vector3(-velocity.x, 0, 0);
        leftChild.radius = childRadius;

        rightChild.velocity = new Vector3(velocity.x, 0, 0);
        rightChild.radius = childRadius;
    }
}
