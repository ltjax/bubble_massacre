using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    private Transform bottom;
    private Transform left;
    private Transform right;
    private Transform top;

    public float width = 16.0f;
    public float height = 8.0f;

    public int currentRopes = 0;

    private void Awake()
    {
        bottom = transform.Find("Bottom");
        left = transform.Find("Left");
        right = transform.Find("Right");
        top = transform.Find("Top");
    }

    // Start is called before the first frame update
    void Start()
    {
        bottom.localScale = new Vector3(width, 0.5f, 1.0f);
        top.localScale = new Vector3(width, 0.5f, 1.0f);
        top.localPosition = new Vector3(0, height + 0.25f, 0f);
        left.localScale = new Vector3(0.5f, height, 1.0f);
        left.localPosition = new Vector3(-(width - 0.5f) * 0.5f, height * 0.5f, 0.0f);
        right.localScale = new Vector3(0.5f, height, 1.0f);
        right.localPosition = new Vector3((width - 0.5f) * 0.5f, height * 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool DoesRopeCollide(Vector3 startingPoint, float currentLength)
    {
        return (startingPoint.y + currentLength) >= height;
    }

    public bool DoesCollideWithBorder(Vector3 position, float radius, out Vector2 normal)
    {
        if (position.x + radius >= 0.5f * width)
        {
            normal = Vector2.left;
            return true;
        }
        else if (position.x - radius <= -0.5f * width)
        {
            normal = Vector2.right;
            return true;
        }
        else if (position.y - radius <= 0.0)
        {
            normal = Vector2.up;
            return true;
        }
        else if (position.y + radius >= height)
        {
            normal = Vector2.down;
            return true;
        }
        normal = Vector2.zero;
        return false;
    }

}
