using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khnumianlife : MonoBehaviour
{
    int damage = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            damage += 1;
            if (damage == 2)
            {
                Destroy(gameObject);
            }
        }

    }
}
