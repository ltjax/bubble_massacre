using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public float growSpeed = 1.0f;
    private LevelScript levelScript;

    // Start is called before the first frame update
    void Start()
    {
        levelScript = GameObject.Find("Level").GetComponent<LevelScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale + new Vector3(0.0f, growSpeed * Time.deltaTime, 0.0f);

        if (levelScript.DoesRopeCollide(transform.position, transform.localScale.y))
        {
            Destroy(transform.gameObject);
            levelScript.currentRopes--;
        }
    }
}
