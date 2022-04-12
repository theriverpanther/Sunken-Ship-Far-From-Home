using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firelaser : MonoBehaviour 
{
    private float lastfire;
    public float firerate;
    public GameObject laserprefab;

    public GameMenuManager manager;

    private void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<GameMenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.paused)
        {
            if (Input.GetButton("Fire1") && Time.time > lastfire + firerate)
            {
                lastfire = Time.time;
                fireslaser();
            }
        }
    }

    void fireslaser()
    {
        GameObject laser = GameObject.Instantiate(laserprefab, transform.position, transform.rotation) as GameObject;  
    }
}
