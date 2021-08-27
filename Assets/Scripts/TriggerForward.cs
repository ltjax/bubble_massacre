using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForward : MonoBehaviour
{
    private BubbleScript bubble;

    // Start is called before the first frame update
    void Start()
    {
        bubble = transform.parent.GetComponent<BubbleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger from Child");
        bubble.OnTriggerEnter(other);
    }
}
