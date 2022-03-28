using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingLightScript : MonoBehaviour
{
    public GameObject onOff;
    public bool isOn = false;
    public bool isOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.E) && !isOn && !isOnCooldown)
       {
            onOff.gameObject.SetActive(true);
            isOn = true;
            isOnCooldown = true;
            StartCoroutine(GuidingLightOnOff());
            StartCoroutine(GuidingLightCooldown());
       }
    }

    IEnumerator GuidingLightOnOff()
    {
        yield return new WaitForSeconds(5);
        onOff.gameObject.SetActive(false);
        isOn = false;
    }
    IEnumerator GuidingLightCooldown()
    {
        yield return new WaitForSeconds(10);
        isOnCooldown = false;
    }

}

