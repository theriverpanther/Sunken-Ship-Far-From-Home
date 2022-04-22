using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatheritem : MonoBehaviour
{
    firelaser f = new firelaser();
  
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "weaponupgrade")
        {
            Debug.Log("We hit weapon");
            f.abletoshoot_megalaser = true;
           Destroy(col.gameObject);
           // col.gameObject.SetActive(false);
        }

        /*if (col.gameObject.tag == "movementupgrade")
        {
            // do the movement upgrade here
           // Destroy(col.gameObject);
        }*/
   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
