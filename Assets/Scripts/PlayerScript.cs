using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public int maxRopes = 2;
    public GameObject ropePrefab;

    private LevelScript levelScript;

    // Start is called before the first frame update
    void Start()
    {
        levelScript = GameObject.Find("Level").GetComponent<LevelScript>();
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
        if (levelScript.currentRopes < maxRopes)
        {
            Instantiate(ropePrefab, transform.position, Quaternion.identity);
            levelScript.currentRopes++;
        }
    }
}
