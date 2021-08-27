using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public int maxRopes = 2;
    
    private RopeManager ropeManager;

    // Start is called before the first frame update
    void Start()
    {
        ropeManager = GameObject.Find("RopeManager").GetComponent<RopeManager>();
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
        ropeManager.ShootRope(this);
    }
}
