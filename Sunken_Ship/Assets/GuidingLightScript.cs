using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidingLightScript : MonoBehaviour
{
    public GameObject onOff;
    public bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.E) && !isOn)
       {
            onOff.gameObject.SetActive(true);
            isOn = true;
            StartCoroutine(GuidingLightCooldown());
       }
    }

    IEnumerator GuidingLightCooldown()
    {
        yield return new WaitForSeconds(5);
        onOff.gameObject.SetActive(false);
        isOn = false;
    }

}

