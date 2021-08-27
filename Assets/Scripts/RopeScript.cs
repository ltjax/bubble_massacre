using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public float growthSpeed = 1.0f;

    Transform ropeModel;

    // Start is called before the first frame update
    void Start()
    {
        ropeModel = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        ropeModel.transform.position = ropeModel.transform.position + new Vector3(0.0f, growthSpeed * Time.deltaTime);
        ropeModel.localScale = ropeModel.localScale + new Vector3(0.0f, growthSpeed * Time.deltaTime);
    }

    public float GetCurrentLength()
    {
        return ropeModel.localScale.y * 2.0f;
    }
}
