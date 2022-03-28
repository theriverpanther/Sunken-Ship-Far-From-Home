using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryshooting : MonoBehaviour
{
   // [SerializeField] Transform target;
    private float lastfire;
    public float firerate;
    public GameObject laserprefab;




    // Update is called once per frame
    void Update()
    {

        if (Time.time > lastfire + firerate)
        {
            lastfire = Time.time;
            fireslaser();

        }


    }

    void fireslaser()
    {
        GameObject laser = GameObject.Instantiate(laserprefab, transform.position, transform.rotation) as GameObject;
    }
}
