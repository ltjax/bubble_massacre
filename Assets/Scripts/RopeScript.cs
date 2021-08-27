using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public float growthSpeed = 1.0f;
    public float length = 0.0f;
    public float radius = 0.1f;

    Transform ropeModel;

    // Start is called before the first frame update
    void Start()
    {
        ropeModel = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        length += growthSpeed * Time.deltaTime;
        UpdateViewLength();
    }

    private void UpdateViewLength()
    {
        ropeModel.transform.localPosition = new Vector3(0.0f, length * 0.5f);
        ropeModel.transform.localScale = new Vector3(radius, length * 0.5f, radius);
    }

    public float GetCurrentLength()
    {
        return length;
    }
}
