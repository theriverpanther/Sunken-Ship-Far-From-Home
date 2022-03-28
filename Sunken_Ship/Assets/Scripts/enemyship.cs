using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyship : MonoBehaviour
{
    public float torque = 500f;
    public float thrust = 1000f;
    private Rigidbody rb;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fly();

        /*
        transform.LookAt(player);

        Vector3 targetlocation = player.position - transform.position;
        float distance = targetlocation.magnitude;
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 3) / 50, 0f, 1f) * thrust);*/
    }

    void fly()
    {
        Vector3 targetdir = player.position - transform.position;
        float xyangle = vector3angleonplane(player.position, transform.position, transform.forward, transform.up);
        float yzangle = vector3angleonplane(player.position, transform.position, transform.right, transform.forward);

        if (Mathf.Abs(xyangle) >= 1f && Mathf.Abs(yzangle) >= 1f)
        {
            rb.AddRelativeTorque(Vector3.forward * -torque * (xyangle / Mathf.Abs(xyangle)));
        }
        else if (yzangle >= 1f)
        {
            rb.AddRelativeTorque(Vector3.right * -torque);
        }
        rb.AddRelativeForce(Vector3.forward * thrust);
    }

    float vector3angleonplane(Vector3 from, Vector3 to, Vector3 planeNormal, Vector3 toOrientation)
    {
        Vector3 projectedVector = Vector3.ProjectOnPlane(from - to, planeNormal);
        float projectedVectorAngle = Vector3.SignedAngle(projectedVector, toOrientation, planeNormal);

        return projectedVectorAngle;
    }
}
