using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarPulse : MonoBehaviour
{
    [SerializeField]
    Vector3 endPos;
    [SerializeField]
    Vector3 startPos;
    [SerializeField]
    float startFOV;
    [SerializeField]
    float endFOV;
    [SerializeField]
    Camera camera;
    [SerializeField]
    float pulseSpeed;

    private float length;
    private float diffFOV;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        // Keep track of when the movement started
        startTime = Time.time;

        // Calculate the distance the camera travels
        length = Vector3.Distance(startPos, endPos);

        // Calculate the change in FOV
        diffFOV = endFOV - startFOV;
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * pulseSpeed;

        float distTraveled = distCovered / length;

        camera.transform.localPosition = Vector3.Lerp(startPos, endPos, distTraveled);

        camera.fieldOfView = Mathf.Lerp(startFOV, endFOV, distTraveled);
        if(Vector3.Distance(camera.transform.localPosition, endPos) <= 0.5)
        {
            camera.transform.localPosition = startPos;
            camera.fieldOfView = startFOV;
            startTime = Time.time;
        }
    }
}
