using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 1.0f;
    public int maxRopes = 2;
    
    private RopeManager ropeManager;
    private Animator animator;
    private readonly int animationSpeed = Animator.StringToHash("Speed");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ropeManager = GameObject.Find("RopeManager").GetComponent<RopeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var realSpeed = speed * x;

        transform.position = new Vector3(transform.position.x + realSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRope();
        }

        if (x > 0.1f)
        {
            transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.up);
        }
        else if (x < -0.1f)
        {
            transform.localRotation = Quaternion.AngleAxis(-90.0f, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(180.0f, Vector3.up);
        }
        

        animator.SetFloat(animationSpeed, Mathf.Abs(realSpeed));
    }

    void ShootRope()
    {
        ropeManager.ShootRope(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {
            OnHitByBubble();
        }
    }

    private void OnHitByBubble()
    {
        Destroy(this.gameObject);
    }
}
