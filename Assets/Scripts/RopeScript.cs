using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public float growthSpeed = 1.0f;
    public float length = 0.0f;
    public float radius = 100.0f;

    Transform ropeModel;
    Transform hookModel;
    private CapsuleCollider collider;

    float levelHeight;

    // Start is called before the first frame update
    void Start()
    {
        levelHeight = GameObject.Find("Level").GetComponent<LevelScript>().height;
        ropeModel = transform.GetChild(0);
        hookModel = transform.GetChild(1);

        collider = GetComponent<CapsuleCollider>();
        UpdateViewLength();
    }

    // Update is called once per frame
    void Update()
    {
        length += growthSpeed * Time.deltaTime;
        UpdateViewLength();
    }

    private void UpdateViewLength()
    {
        hookModel.transform.localPosition = new Vector3(0.0f, length);
        ropeModel.transform.localScale = new Vector3(radius, radius, length * 100.0f / (levelHeight-0.5f));
        collider.radius = 0.05f;
        collider.height = length;
        collider.center = length / 2 * Vector3.up;
    }

    public float GetCurrentLength()
    {
        return length;
    }
}
