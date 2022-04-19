using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    // Game State
  //  [SerializeField] GameMenuManager manager;

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
    [SerializeField] private float vPitchCurrent;
    [SerializeField] private float vMouseCurrentx;
    [SerializeField] private float vMouseCurrenty;

    //Camera Rotate
    private Vector2 lookInput;
    private Vector2 screenCenter;
    private Vector2 mouseDistance;

    //Forces
    Rigidbody rb;

    //ANIMATION
    //Fans
    GameObject rightFront;
    GameObject rightMiddle;
    GameObject rightBack;
    GameObject leftFront;
    GameObject leftMiddle;
    GameObject leftBack;
    //Bubbles
    ParticleSystem.MainModule rightFrontB;
    ParticleSystem.MainModule rightMiddleB;
    ParticleSystem.MainModule rightBackB;
    ParticleSystem.MainModule leftFrontB;
    ParticleSystem.MainModule leftMiddleB;
    ParticleSystem.MainModule leftBackB;

    // Start is called before the first frame update
    void Start()
    {
        // Game State Tracking
       // manager = GameObject.Find("Canvas").GetComponent<GameMenuManager>();

        Cursor.visible = false;
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;
        rb = gameObject.GetComponent<Rigidbody>();

        //Animation FANS
        rightFront = GameObject.Find("Rf_empty");
        rightMiddle = GameObject.Find("Rm_empty");
        rightBack = GameObject.Find("Rb_empty");
        leftFront = GameObject.Find("Lf_empty");
        leftMiddle = GameObject.Find("Lm_empty");
        leftBack = GameObject.Find("Lb_empty");

        //Animation BUBBLES
        rightFrontB = GameObject.Find("Rf_bubbles").GetComponent<ParticleSystem>().main;
        rightMiddleB = GameObject.Find("Rm_bubbles").GetComponent<ParticleSystem>().main;
        rightBackB = GameObject.Find("Rb_bubbles").GetComponent<ParticleSystem>().main;
        leftFrontB = GameObject.Find("Lf_bubbles").GetComponent<ParticleSystem>().main;
        leftMiddleB = GameObject.Find("Lm_bubbles").GetComponent<ParticleSystem>().main;
        leftBackB = GameObject.Find("Lb_bubbles").GetComponent<ParticleSystem>().main;
    }

    // Update is called once per frame
    void Update()
    {
      //  if(!manager.paused)
        {
            //Get Mouse Location on Screen
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;
            mouseDistance.x = Mathf.Pow((lookInput.x - screenCenter.x) / screenCenter.y, 3);
            mouseDistance.y = Mathf.Pow((lookInput.y - screenCenter.y) / screenCenter.y, 3);
            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);


            //Calculate Linear Interpolation for Input
            vMouseCurrentx = Mathf.Lerp(vMouseCurrentx, mouseDistance.x, aMouse * Time.deltaTime);
            vMouseCurrenty = Mathf.Lerp(vMouseCurrenty, mouseDistance.y, aMouse * Time.deltaTime);

            vForwardCurrent = Mathf.Lerp(vForwardCurrent, Input.GetAxisRaw("Vertical") * vForward, aForward * Time.deltaTime); //W and S for forward/back
            vRollCurrent = Mathf.Lerp(vRollCurrent, Input.GetAxisRaw("Horizontal") * -vRoll, aSide * Time.deltaTime); //A and D for rolling left and right


            //Level out ship's roll
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                if (transform.rotation.eulerAngles.z > 180)
                {
                    vRollCurrent = Mathf.Lerp(vRollCurrent, 1.0f * vRoll / 2, aSide * Time.deltaTime);
                }
                else if (transform.rotation.eulerAngles.z < 180)
                {
                    vRollCurrent = Mathf.Lerp(vRollCurrent, -1.0f * vRoll / 2, aSide * Time.deltaTime);
                    //transform.Rotate(0, 0, -0.05f);
                }
            }
            //Level out ship's pitch
            if (Mathf.Abs(mouseDistance.y) < 0.1f) //If mouse is close enough, rotate pitch towards horizon
            {
                if (transform.rotation.eulerAngles.x > 180)
                {
                    vPitchCurrent = Mathf.Lerp(vPitchCurrent, 1.0f * lookRotateSpeed / 4, aMouse * Time.deltaTime);
                    //transform.Rotate(0.02f, 0.0f, 0.0f);
                }
                if (transform.rotation.eulerAngles.x < 180)
                {
                    vPitchCurrent = Mathf.Lerp(vPitchCurrent, -1.0f * lookRotateSpeed / 4, aMouse * Time.deltaTime);
                }
            }
            else //If mouse is a certain distance away, move pitch towards mouse direction
            {
                vPitchCurrent = -vMouseCurrenty * lookRotateSpeed;
            }


            //Rotation code for each axis, x and y are controlled by the mouse and z is controlled by pressing A and D
            transform.Rotate(vPitchCurrent * Time.deltaTime, vMouseCurrentx * lookRotateSpeed * Time.deltaTime, vRollCurrent * Time.deltaTime, Space.Self);

            //Calculate Forward Velcoity and move with rigidbody velocity
            rb.velocity = new Vector3(transform.forward.x * vForwardCurrent, transform.forward.y * vForwardCurrent, transform.forward.z * vForwardCurrent);


            //vSideCurrent = Mathf.Lerp(vSideCurrent, Input.GetAxisRaw("Horizontal") * vSide, aSide * Time.deltaTime);
            //vVerticalCurrent = Mathf.Lerp(vVerticalCurrent, Input.GetAxisRaw("Hover") * vVertical, aVertical * Time.deltaTime);
            /*
            transform.position += transform.forward * vForwardCurrent * Time.deltaTime;
            transform.position += transform.right * vSideCurrent * Time.deltaTime;
            transform.position += transform.up * vVerticalCurrent * Time.deltaTime;
            */


            //ANIMATION SECTION

            //Forward and Backward
            rightMiddle.transform.Rotate(0.0f, 0.0f, vForwardCurrent, Space.Self);
            leftMiddle.transform.Rotate(0.0f, 0.0f, vForwardCurrent, Space.Self);
            rightMiddleB.simulationSpeed = Mathf.Abs(vForwardCurrent);
            leftMiddleB.simulationSpeed = Mathf.Abs(vForwardCurrent);
            rightMiddleB.startSpeed = Mathf.Round(vForwardCurrent);
            leftMiddleB.startSpeed = Mathf.Round(vForwardCurrent);

            //Look up/down
            rightBack.transform.Rotate(0.0f, vMouseCurrenty * 20, 0.0f, Space.Self);
            leftBack.transform.Rotate(0.0f, vMouseCurrenty * 20, 0.0f, Space.Self);
            rightBackB.simulationSpeed = Mathf.Abs(vMouseCurrenty * 20);
            leftBackB.simulationSpeed = Mathf.Abs(vMouseCurrenty * 20);
            rightBackB.startSpeed = Mathf.Round(vMouseCurrenty * 20);
            leftBackB.startSpeed = Mathf.Round(vMouseCurrenty * 20);

            //Look left/right
            rightFront.transform.Rotate(0.0f, vMouseCurrentx * 20, 0.0f, Space.Self);
            leftFront.transform.Rotate(0.0f, -vMouseCurrentx * 20, 0.0f, Space.Self);
            rightFrontB.simulationSpeed = Mathf.Abs(vMouseCurrentx * 20);
            leftFrontB.simulationSpeed = Mathf.Abs(vMouseCurrentx * 20);
            rightFrontB.startSpeed = Mathf.Round(vMouseCurrentx * 20);
            leftFrontB.startSpeed = Mathf.Round(-vMouseCurrentx * 20);

            //ROLL
            if (Input.GetAxisRaw("Horizontal") != 0) //Prevent rotations being altered by the leveling-out mechanic
            {
                rightFront.transform.Rotate(0.0f, -vRollCurrent, 0.0f, Space.Self);
                leftFront.transform.Rotate(0.0f, vRollCurrent, 0.0f, Space.Self);
                rightBack.transform.Rotate(0.0f, -vRollCurrent, 0.0f, Space.Self);
                leftBack.transform.Rotate(0.0f, vRollCurrent, 0.0f, Space.Self);

                rightFrontB.simulationSpeed = Mathf.Abs(-vRollCurrent);
                leftFrontB.simulationSpeed = Mathf.Abs(vRollCurrent);
                rightFrontB.startSpeed = Mathf.Round(-vRollCurrent);
                leftFrontB.startSpeed = Mathf.Round(vRollCurrent);
                rightBackB.simulationSpeed = Mathf.Abs(-vRollCurrent);
                leftBackB.simulationSpeed = Mathf.Abs(vRollCurrent);
                rightBackB.startSpeed = Mathf.Round(-vRollCurrent);
                leftBackB.startSpeed = Mathf.Round(vRollCurrent);
            }
            else
            {
                rightFront.transform.Rotate(0.0f, vRollCurrent / 4, 0.0f, Space.Self);
                leftFront.transform.Rotate(0.0f, -vRollCurrent / 4, 0.0f, Space.Self);
                rightBack.transform.Rotate(0.0f, vRollCurrent / 4, 0.0f, Space.Self);
                leftBack.transform.Rotate(0.0f, -vRollCurrent / 4, 0.0f, Space.Self);

                rightFrontB.simulationSpeed = Mathf.Abs(vMouseCurrentx * 20);
                leftFrontB.simulationSpeed = Mathf.Abs(vMouseCurrentx * 20);
                rightFrontB.startSpeed = Mathf.Round(vMouseCurrentx * 20);
                leftFrontB.startSpeed = Mathf.Round(-vMouseCurrentx * 20);
                rightBackB.simulationSpeed = Mathf.Abs(vMouseCurrenty * 20);
                leftBackB.simulationSpeed = Mathf.Abs(vMouseCurrenty * 20);
                rightBackB.startSpeed = Mathf.Round(vMouseCurrenty * 20);
                leftBackB.startSpeed = Mathf.Round(vMouseCurrenty * 20);
            }
        }
    }
}
