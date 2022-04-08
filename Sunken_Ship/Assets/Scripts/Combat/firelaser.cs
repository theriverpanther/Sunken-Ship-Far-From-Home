using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firelaser : MonoBehaviour 
{
    private float lastfire;
    public float firerate;
    public GameObject laserprefab;
    public GameObject flarePrefab;

    //Swap between
    public bool useFlare = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > lastfire + firerate)
        {
            lastfire = Time.time;

            if (useFlare)
            {
                FireFlare();
            }
            else
            {
                fireslaser();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (useFlare)
            {
                useFlare = false;
            }
            else
            {
                useFlare = true;
            }
        }
    }

    void fireslaser()
    {
        GameObject laser = GameObject.Instantiate(laserprefab, transform.position, transform.rotation) as GameObject;  
    }

    //Added Flare
    void FireFlare()
    {
        GameObject flare = GameObject.Instantiate(flarePrefab, transform.position, transform.rotation) as GameObject;
    }
}
