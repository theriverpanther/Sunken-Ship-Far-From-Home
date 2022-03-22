using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarPulse : MonoBehaviour
{
    [SerializeField]
    Vector3 startScale;
    [SerializeField]
    Vector3 endScale;
    [SerializeField]
    float pulseSpeed;
    [SerializeField]
    GameObject hitbox;

    private float length;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        // Keep track of when the movement started
        startTime = Time.time;

        // Calculate the change in scale
        length = Vector3.Distance(startScale, endScale);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * pulseSpeed;

        float distTraveled = distCovered / length;

        hitbox.transform.localScale = Vector3.Lerp(startScale, endScale, distTraveled);

        if(Vector3.Distance(hitbox.transform.localScale, endScale) <= 0.5)
        {
            hitbox.transform.localScale = startScale;
            startTime = Time.time;
        }
    }
}
