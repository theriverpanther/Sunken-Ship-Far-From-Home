using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraDistortion : MonoBehaviour
{
    [SerializeField]
    LensDistortion distortion;
    
    public float speed;
    public bool invert;
    
    [Range (-1.0f,0.0f)]
    float minX;
    [Range (0.0f, 1.0f)]
    float maxX;
    [Range (-1.0f,0.0f)]
    float minY;
    [Range (0.0f, 1.0f)]
    float maxY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(invert)
        {
            distortion.centerX.value = Mathf.Clamp(Mathf.Cos(speed * Time.deltaTime), minX, maxX));
            distortion.centerY.value = Mathf.Clamp(Mathf.Sin(speed * Time.deltaTime), minY, maxY));
        }
        else
        {
            distortion.centerX.value = Mathf.Clamp(Mathf.Sin(speed * Time.deltaTime), minX, maxX));
            distortion.centerY.value = Mathf.Clamp(Mathf.Cos(speed * Time.deltaTime), minY, maxY));
        }
    }
}
