using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserbeam : MonoBehaviour
{
    public float speed = 70f;
    public float genesis;
    // Start is called before the first frame update
    void Start()
    {
        genesis = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > genesis + 3.0f)
            Destroy(gameObject);
        transform.position += transform.forward * Time.deltaTime * speed;
        
    }
}
