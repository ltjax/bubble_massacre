using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject ropePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + x * Time.deltaTime * speed, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRope();
        }
    }

    void ShootRope()
    {
        Instantiate(ropePrefab, transform.position, Quaternion.identity);
    }
}
