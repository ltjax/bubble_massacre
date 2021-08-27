using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0.02f, 0.0f, 0.0f);
    public float radius = 1.0f;

    private LevelScript level;
    private Transform sphere;
    private RopeManager ropeManager;
    private BubbleManager bubbleManager;

    // Start is called before the first frame update
    void Start()
    {
        bubbleManager = GameObject.Find("BubbleManager").GetComponent<BubbleManager>();
        ropeManager = GameObject.Find("RopeManager").GetComponent<RopeManager>();
        level = GameObject.Find("Level").GetComponent<LevelScript>();

        sphere = transform.Find("Sphere");
        sphere.localScale = new Vector3(2 * radius, 2 * radius, 2 * radius);
    }

    // Update is called once per frame
    void Update()
    {
        velocity += level.gravity * Time.deltaTime;
        Advance();

        if (level.DoesCollideWithBorder(transform.position, radius, out var normal))
        {
            velocity = Reflect(velocity, new Vector3(normal.x, normal.y, 0));
            Advance();
        }
    }

    void Advance()
    {
        transform.localPosition = transform.localPosition + velocity * Time.deltaTime;
    }

    Vector3 Reflect(Vector3 velocity, Vector3 normal)
    {
        return velocity - 2 * Vector3.Dot(velocity, normal) * normal;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rope"))
        {
            CollisionWithRope();
            ropeManager.DestroyOnCollision(other.gameObject);
        }
    }

    void CollisionWithRope()
    {
        bubbleManager.HitBubble(transform.gameObject);
    }
}
