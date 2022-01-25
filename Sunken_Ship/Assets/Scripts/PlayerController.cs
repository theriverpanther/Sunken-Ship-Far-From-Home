using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Fields
    Rigidbody rb;
    [SerializeField] float forceVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 1.5f;
        rb.maxDepenetrationVelocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        forceVector = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.x, 2)); //Distance Formula

        //Rotate
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(new Vector3(0, -0.15f, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(new Vector3(0, 0.15f, 0));
        }

        //Slow Angular Velocity
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(new Vector3(0, rb.angularVelocity.y * -0.1f, 0));

            if(Mathf.Abs(rb.angularVelocity.y) < 0.5)
            {
                rb.angularVelocity = new Vector3(0, 0, 0);
            }
        }

        //Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * 2);
            if(rb.velocity.magnitude > 5)
            {
                rb.velocity = rb.velocity.normalized * 5;
            }
        }
        else
        {
            if(Mathf.Abs(rb.velocity.x) > 0)
            {
                rb.AddForce(new Vector3(rb.velocity.x * -0.3f, 0, 0));
            }
            if (Mathf.Abs(rb.velocity.z) > 0)
            {
                rb.AddForce(new Vector3(0, 0, rb.velocity.z * -0.3f));
            }
        }
    }
}
