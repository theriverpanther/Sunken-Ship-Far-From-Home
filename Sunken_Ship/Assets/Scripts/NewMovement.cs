using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    //Movement Speeds
    [SerializeField] float vForward = 20f;
    [SerializeField] float vRoll = 20f;
    //Current Forward Velocity
    private float vForwardActive;
    //Acceleration
    private float aForward = 2.5f;
    private float aSide = 2f;
    //Camera Rotate
    [SerializeField] float lookRotateSpeed = 90f;
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;
    //Roll
    float rollInput;

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
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //Get Keyboard Input
        vForwardActive = Mathf.Lerp(vForwardActive, Input.GetAxisRaw("Vertical") * vForward, aForward * Time.deltaTime); //W and S for forward/back
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Horizontal") * -1, aSide * Time.deltaTime); //A and D for rolling left and right

        //Rotation code for each axis, x and y are controlled by the mouse and z is controlled by pressing A and D
        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, rollInput * vRoll * Time.deltaTime, Space.Self);

        //Calculate Forward Velcoity and move with rigidbody velocity
        rb.velocity = new Vector3(transform.forward.x * vForwardActive, transform.forward.y * vForwardActive, transform.forward.z * vForwardActive);


        //vSideActive = Mathf.Lerp(vSideActive, Input.GetAxisRaw("Horizontal") * vSide, aSide * Time.deltaTime);
        //vVerticalActive = Mathf.Lerp(vVerticalActive, Input.GetAxisRaw("Hover") * vVertical, aVertical * Time.deltaTime);
        /*
        transform.position += transform.forward * vForwardActive * Time.deltaTime;
        transform.position += transform.right * vSideActive * Time.deltaTime;
        transform.position += transform.up * vVerticalActive * Time.deltaTime;
        */
    }
}
