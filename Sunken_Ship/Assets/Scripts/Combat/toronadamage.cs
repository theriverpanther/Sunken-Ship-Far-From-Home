using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toronadamage : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {

            Destroy(col.gameObject);
        }

    }
}
