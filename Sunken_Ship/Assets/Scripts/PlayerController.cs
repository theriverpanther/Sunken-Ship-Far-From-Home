using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Fields
    Rigidbody rb;
    //[SerializeField] float forceVector;
    [SerializeField] float velocity = 0;
    [SerializeField] float angularVelocity = 0;
    [SerializeField] Vector3 test;
    [SerializeField] float energy = 1;
    EnergyBar barScript;

    const float acceleration = 0.03f;
    const float angularAcc = 0.003f;
    const float maxVelocity = 6.0f;
    const float maxAngularVelocity = 1.0f;
    const float jumpBoost = 1.5f;
    const float jumpDrain = 0.002f;
    const float jumpRefill = 0.0005f;
    
    
    public Transform originalRotationValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.maxAngularVerblocity = 1.5f;
        rb.maxDepenetrationVelocity = 1;
        barScript = FindObjectOfType<EnergyBar>();
       
        
        originalRotationValue = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        rb.velocity = new Vector3(transform.forward.x * velocity, rb.velocity.y, transform.forward.z * velocity);
        rb.angularVelocity = new Vector3(rb.angularVelocity.x, angularVelocity, rb.angularVelocity.z);

        //Rotate submarine with A and D
        if (Input.GetKey(KeyCode.A))
        {
            if (angularVelocity > -maxAngularVelocity)
            {
                angularVelocity -= angularAcc;
                //rb.AddTorque(new Vector3(0, -1.0f, 0));
                //transform.Rotate(0, -0.15f, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (angularVelocity < maxAngularVelocity)
            {
                angularVelocity += angularAcc;
                //rb.AddTorque(new Vector3(0, 100.0f, 0));
                //transform.Rotate(0, 0.15f, 0);
            }
        }
        else //Slow Down if not pressed
        {
            if (angularVelocity > 0)
            {
                angularVelocity -= (angularAcc / 4);
            }
            if (angularVelocity < 0)
            {
                angularVelocity += (angularAcc / 4);
            }
        }

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
            if (velocity > -maxVelocity)
            {
                velocity -= acceleration;
            }
        }
        else //Slow down if forward or back button not pressed
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

        //Jump
        if(Input.GetKey(KeyCode.Space) && energy > 0)
        {
            energy -= jumpDrain;
            rb.AddForce(0, jumpBoost, 0);

            //Call Bar Script
            barScript.ChangeBar(energy);
        }

        //Refill Jump Bar
        if(Mathf.Abs(rb.velocity.y) < 0.1f && energy < 1.0f)
        {
            energy += jumpRefill;

            //Call Bar Script
            barScript.ChangeBar(energy);
        }

        if (Input.GetKey(KeyCode.R))
        {
            gameObject.transform.Rotate(0, 0, 1);

        }
    }
}
