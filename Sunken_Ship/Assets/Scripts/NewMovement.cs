using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    //Max Speeds
    public float vForward= 10f;
    public float vSide = 7.5f;
    public float vVertical = 20f;
    //Current Speeds
    private float vForwardActive;
    private float vSideActive;
    private float vVerticalActive;
    //Acceleration
    private float aForward = 2.5f;
    private float aSide = 2f;
    private float aVertical = 2f;
    //Camera Rotate
    public float lookRotateSpeed = 90f;
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
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //Rotate
        transform.Rotate(-mouseDistance.y * lookRotateSpeed * Time.deltaTime, mouseDistance.x * lookRotateSpeed * Time.deltaTime, 0f, Space.Self);


        vForwardActive = Mathf.Lerp(vForwardActive, Input.GetAxisRaw("Vertical") * vForward, aForward * Time.deltaTime);
        vSideActive = Mathf.Lerp(vSideActive, Input.GetAxisRaw("Horizontal") * vSide, aSide * Time.deltaTime);
        vVerticalActive = Mathf.Lerp(vVerticalActive, Input.GetAxisRaw("Hover") * vVertical, aVertical * Time.deltaTime);

        /*
        transform.position += transform.forward * vForwardActive * Time.deltaTime;
        transform.position += transform.right * vSideActive * Time.deltaTime;
        transform.position += transform.up * vVerticalActive * Time.deltaTime;
        */

        rb.velocity = new Vector3(transform.forward.x * vForwardActive, transform.forward.y * vForwardActive, transform.forward.z * vForwardActive);
    }
}
