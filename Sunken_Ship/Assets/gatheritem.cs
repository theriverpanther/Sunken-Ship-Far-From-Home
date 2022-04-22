using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatheritem : MonoBehaviour
{
    firelaser f;
    NewMovement n;
  
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "weaponupgrade")
        {
            Debug.Log("We hit weapon");
            f.abletoshoot_megalaser = true;
           Destroy(col.gameObject);
          
        }

        if (col.gameObject.tag == "movementupgrade")
        {
            Debug.Log("We hit movementupgrade");
            n.upgrade = true;
            Destroy(col.gameObject);
            
        }
   
    }
    // Start is called before the first frame update
    void Start()
    {
        f = FindObjectOfType<firelaser>();
        n = FindObjectOfType<NewMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
