using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletkill : MonoBehaviour
{
   // public int maxbulletforturret;
    public int currentbullethit;
    // Start is called before the first frame update
    void Start()
    {
      // maxbulletforturret = 3;
       currentbullethit = 0;
    }


    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Khnumian")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "turret")
        {
            currentbullethit += currentbullethit;
            Debug.Log(currentbullethit);
            if (currentbullethit == 3)
            {
                Destroy(col.gameObject);
            }
        }
    }*/
            // Update is called once per frame
            void Update()
             {
        
             }
    void updatehealth()
    { 
    
    }
}
