using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraDistortion : MonoBehaviour
{
    [SerializeField]
    PostProcessProfile profile;
    LensDistortion distortion;
    
    public float speed;
    public bool invert;
    
    [Range (-5.0f,0.0f)]
    public float minX;
    [Range (0.0f, 5.0f)]
    public float maxX;
    [Range (-5.0f,0.0f)]
    public float minY;
    [Range (0.0f, 5.0f)]
    public float maxY;

    private float xRange;
    private float yRange;

    private float timeRan = 0;
    // Start is called before the first frame update
    void Start()
    {
        profile.TryGetSettings(out distortion);
        xRange = maxX - minX;
        yRange = maxY - minY;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Sine Wave
        float x;
        float y;
        // Move clockwise
        if(invert)
        {
            x = Mathf.Cos(speed * timeRan)* xRange;
            y = Mathf.Sin(speed * timeRan)* yRange;
            
        }
        // Move counter-clockwise
        else
        {
            x = Mathf.Sin(speed * timeRan) * xRange;
            y = Mathf.Cos(speed * timeRan)* yRange;
        }
        // Adjust the filter values
        distortion.centerX.value = x;
        distortion.centerY.value = y;

        // Add to the timer
        timeRan += Time.deltaTime;
    }
}
