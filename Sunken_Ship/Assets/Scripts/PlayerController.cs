using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Fields
    Rigidbody rb;
    //[SerializeField] float forceVector;
    [SerializeField] float velocity = 0;
    [SerializeField] Vector3 test;
    const float acceleration = 0.05f;
    const float maxVelocity = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.maxAngularVerblocity = 1.5f;
        rb.maxDepenetrationVelocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //forceVector = Mathf.Sqrt(Mathf.Pow(velocity, 2) + Mathf.Pow(velocity, 2)); //Distance Formula

        //Rotate
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(new Vector3(0, -0.15f, 0));
            transform.Rotate(0, -0.15f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(new Vector3(0, 0.15f, 0));
            transform.Rotate(0, 0.15f, 0);
        }

        //Slow Angular Velocity
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(new Vector3(0, rb.angularVelocity.y * -0.01f, 0));

            if(Mathf.Abs(rb.angularVelocity.y) < 0.5)
            {
                rb.angularVelocity = new Vector3(0, 0, 0);
            }
        }


        //Movement
        rb.velocity = new Vector3(transform.forward.x * velocity, rb.velocity.y, transform.forward.z * velocity);
        //test = Vector3.Normalize(transform.forward) * velocity;
        //transform.position += Vector3.Normalize(transform.forward) * velocity;

        //Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            if(velocity < maxVelocity)
            {
                velocity += acceleration;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (velocity < maxVelocity)
            {
                velocity -= acceleration;
            }
        }
        else
        {
            if(velocity > 0)
            {
                velocity -= (acceleration / 4);
            }
            if (velocity < 0)
            {
                velocity += (acceleration / 4);
            }
        }
    }
}
