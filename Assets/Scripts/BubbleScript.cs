using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0.02f, 0.02f, 0.0f);
    public float radius = 1.0f;

    private LevelScript level;
    private Transform sphere;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level").GetComponent<LevelScript>();

        sphere = transform.Find("Sphere");
        sphere.localScale = new Vector3(radius, radius, radius);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + velocity;

        if (level.DoesCollideWithBorder(transform.position, radius, out var normal))
        {
            velocity = reflect(velocity, new Vector3(normal.x, normal.y, 0));
        }
    }

    Vector3 reflect(Vector3 velocity, Vector3 normal)
    {
        return 2 * Vector3.Dot(velocity, normal) * normal - velocity;
    }
}
