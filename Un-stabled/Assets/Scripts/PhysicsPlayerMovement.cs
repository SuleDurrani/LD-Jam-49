using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (rb.velocity.magnitude < 10)
        {
            if (h > 0.001f)
            {
                rb.AddForce(new Vector3(1000, 0, 0));
            }
            else if (h < -0.001f)
            {
                rb.AddForce(new Vector3(-1000, 0, 0));
            }

            if(v>0.001f && Physics.Raycast(transform.position,Vector3.down,1.1f)){
                rb.AddForce(new Vector3(0, 20000, 0));
            }
        }
    }
}
