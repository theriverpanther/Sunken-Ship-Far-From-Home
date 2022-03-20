using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    //Movement Speeds
    [SerializeField] float vForward = 20f;
    [SerializeField] float vRoll = 50f;
    [SerializeField] float lookRotateSpeed = 50f;

    //Acceleration
    private float aForward = 0.5f;
    private float aSide = 0.5f;
    private float aMouse = 0.8f;

    //Current Velocity
    [SerializeField] private float vForwardCurrent;
    [SerializeField] private float vRollCurrent;
    [SerializeField] private float vMouseCurrentx;
    [SerializeField] private float vMouseCurrenty;

    //Camera Rotate
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    //Forces
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Mouse Location on Screen
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;
        mouseDistance.x = Mathf.Pow((lookInput.x - screenCenter.x) / screenCenter.y, 3);
        mouseDistance.y = Mathf.Pow((lookInput.y - screenCenter.y) / screenCenter.y, 3);
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);


        //Calculate Linear Interpolation for Input
        vForwardCurrent = Mathf.Lerp(vForwardCurrent, Input.GetAxisRaw("Vertical") * vForward, aForward * Time.deltaTime); //W and S for forward/back
        vRollCurrent = Mathf.Lerp(vRollCurrent, Input.GetAxisRaw("Horizontal") * -1, aSide * Time.deltaTime); //A and D for rolling left and right
        vMouseCurrentx = Mathf.Lerp(vMouseCurrentx, mouseDistance.x, aMouse * Time.deltaTime);
        vMouseCurrenty = Mathf.Lerp(vMouseCurrenty, mouseDistance.y, aMouse * Time.deltaTime);


        //Rotation code for each axis, x and y are controlled by the mouse and z is controlled by pressing A and D
        transform.Rotate(-vMouseCurrenty * lookRotateSpeed * Time.deltaTime, vMouseCurrentx * lookRotateSpeed * Time.deltaTime, vRollCurrent * vRoll * Time.deltaTime, Space.Self);

        //Calculate Forward Velcoity and move with rigidbody velocity
        rb.velocity = new Vector3(transform.forward.x * vForwardCurrent, transform.forward.y * vForwardCurrent, transform.forward.z * vForwardCurrent);

        Debug.Log(mouseDistance);

        //Level out ship's roll
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            if(transform.rotation.eulerAngles.z > 180)
            {
                transform.Rotate(0, 0, 0.05f);
            }
            if(transform.rotation.eulerAngles.z < 180)
            {
                transform.Rotate(0, 0, -0.05f);
                //Debug.Log("TEST?");
                //Debug.Log(transform.rotation.eulerAngles.z);
            }
        }

        if (Mathf.Abs(mouseDistance.y) < 0.1f)
        {
            if (transform.rotation.eulerAngles.x > 180)
            {
                transform.Rotate(0.02f, 0.0f, 0.0f);
            }
            if (transform.rotation.eulerAngles.x < 180)
            {
                transform.Rotate(-0.02f, 0.0f, 0.0f);
            }
        }

        //Level out ship's pitch


        //vSideCurrent = Mathf.Lerp(vSideCurrent, Input.GetAxisRaw("Horizontal") * vSide, aSide * Time.deltaTime);
        //vVerticalCurrent = Mathf.Lerp(vVerticalCurrent, Input.GetAxisRaw("Hover") * vVertical, aVertical * Time.deltaTime);
        /*
        transform.position += transform.forward * vForwardCurrent * Time.deltaTime;
        transform.position += transform.right * vSideCurrent * Time.deltaTime;
        transform.position += transform.up * vVerticalCurrent * Time.deltaTime;
        */
    }
}
