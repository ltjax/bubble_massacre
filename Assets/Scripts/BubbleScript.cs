using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public GameObject bubblePrefab;

    public Vector3 velocity = new Vector3(0.02f, 0.0f, 0.0f);
    public float radius = 1.0f;

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
            velocity = reflect(velocity, new Vector3(normal.x, normal.y, 0));
            advance();
        }

        // to simulate what would happen when hit by rope
        if (Input.GetButton("Fire2"))
        {
            split();
        }
    }

    void advance()
    {
        transform.localPosition = transform.localPosition + velocity * Time.deltaTime;
    }

    Vector3 reflect(Vector3 velocity, Vector3 normal)
    {
        return velocity - 2 * Vector3.Dot(velocity, normal) * normal;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("hellooooo");
        sphere.localScale = new Vector3(radius, radius, radius);
    }

    void split()
    {
        var left = Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
        var leftChild = left.GetComponent<BubbleScript>();

        var right = Instantiate(bubblePrefab, transform.localPosition, Quaternion.identity);
        var rightChild = right.GetComponent<BubbleScript>();

        leftChild.velocity = new Vector3(-velocity.magnitude, 0, 0);
        leftChild.radius = radius * 0.5f;

        rightChild.velocity = new Vector3(velocity.magnitude, 0, 0);
        rightChild.radius = radius * 0.5f;

        Destroy(transform.gameObject);
        Debug.Log("Fucking bubble should be gone now!");
    }
}
