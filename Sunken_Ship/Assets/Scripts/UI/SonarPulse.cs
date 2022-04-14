using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonarPulse : MonoBehaviour
{
    [SerializeField]
    Vector3 startScale;
    [SerializeField]
    Vector3 endScale;
    [SerializeField]
    float pulseSpeed;

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

        this.gameObject.transform.localScale = Vector3.Lerp(startScale, endScale, distTraveled);

        if(Vector3.Distance(this.gameObject.transform.localScale, endScale) <= 0.5)
        {
            this.gameObject.transform.localScale = startScale;
            startTime = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10 && other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
